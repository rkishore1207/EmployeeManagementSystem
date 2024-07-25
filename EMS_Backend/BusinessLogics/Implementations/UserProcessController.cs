using AutoMapper;
using BusinessLogics.Helper;
using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using Services.Implementations;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Utilities.Constants;

namespace BusinessLogics.Implementations
{
    public class UserProcessController : IUserProcessController
    {
        private readonly IUserRepository<UserEntity, Guid> _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IHelper _helper;
        private readonly IMapper _mapper;

        public UserProcessController(IUserRepository<UserEntity, Guid> userRepository, ITokenService tokenService, IHelper helper, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _helper = helper;
            _mapper = mapper;
        }

        public async Task<UserViewModel> UserLogin(UserLoginRequest userLogin)
        {
            if (userLogin == null)
                throw new NullReferenceException(Constant.CustomExceptions.InvalidUser);
            var hmac = new HMACSHA512();
            var password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password)) ?? Array.Empty<byte>();
            Guid userUID = await _helper.GetUserIdByEmail(userLogin.Email);
            var userEntity = await _userRepository.GetUser(userUID);
            for (int i = 0; i < userEntity.PasswordHash?.Length; i++)
            {
                if (password[i] != userEntity.PasswordHash[i])
                    throw new UnauthorizedAccessException();
            }
            var user = new UserViewModel()
            {
                UID = userEntity.UID,
                Email = userEntity.Email,
                Role = userEntity.UserRole
            };
            user.Token = _tokenService.GenerateToken(user);
            return user;
        }

        public async Task<UserViewModel> UserRegister(UserRegisterRequest userRegister)
        {
            if (userRegister == null)
                throw new NullReferenceException(Constant.CustomExceptions.InvalidUser);

            if (await IsUserExists(userRegister))
                throw new DuplicateNameException(Constant.CustomExceptions.DuplicateUser);

            var userEntity = _mapper.Map<UserEntity>(userRegister);
            await _userRepository.AddUser(userEntity);
            var user = new UserViewModel()
            {
                UID = userEntity.UID,
                Email = userEntity.Email,
                Role = userEntity.UserRole
            };
            user.Token = _tokenService.GenerateToken(user);
            return user;
        }

        private async Task<bool> IsUserExists(UserRegisterRequest userRegister)
        {
            var users = await _userRepository.GetUsers();
            var existingUser = users.Where(emp => emp.Email == userRegister.Email).FirstOrDefault();
            if (existingUser != null)
                return true;
            return false;
        }
    }
}
