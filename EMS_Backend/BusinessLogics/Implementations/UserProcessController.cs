﻿using AutoMapper;
using AzureServices.Interfaces;
using BusinessLogics.Helper;
using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Services.Implementations;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Utilities.Constants;
using Utilities.Exceptions;

namespace BusinessLogics.Implementations
{
    public class UserProcessController : IUserProcessController
    {
        private readonly IUserRepository<UserEntity, Guid> _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IHelper _helper;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IMapper _mapper;

        public UserProcessController(IUserRepository<UserEntity, Guid> userRepository, ITokenService tokenService, IHelper helper, IBlobStorageService blobStorageService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _helper = helper;
            _blobStorageService = blobStorageService;
            _mapper = mapper;
        }

        public async Task<UserViewModel> UserLogin(UserLoginRequest userLogin)
        {
            if (userLogin is null)
                throw new NullReferenceException(Constant.CustomExceptions.InvalidUser);
            
            var userDetail = await _helper.GetUserIdByEmail(userLogin.Email) ?? throw new CustomException(new Error(Constant.CustomExceptions.InValidEmail,1004), HttpStatusCode.NotFound);
            
            var userEntity = await _userRepository.GetUser(userDetail.UID);
            if (userEntity.PasswordHash is null || userEntity.PasswordHash?.Length <= 0 || userLogin.Password.Length <= 0)
                throw new CustomException(new Error(Constant.CustomExceptions.UnAuthorizedException), HttpStatusCode.Unauthorized);

            var hmac = new HMACSHA512(userEntity.HashKey);
            var password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password)) ?? Array.Empty<byte>();
            
            for (int i = 0; i < userEntity.PasswordHash?.Length; i++)
            {
                if (password[i] != userEntity.PasswordHash[i])
                    throw new CustomException(new Error(Constant.CustomExceptions.InCorrectPassword,1002), HttpStatusCode.Unauthorized);
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

        public async Task<Guid> UserRegister(UserRegisterRequest userRegister)
        {
            if (userRegister == null)
                throw new NullReferenceException(Constant.CustomExceptions.InvalidUser);

            if (await IsUserExists(userRegister))
                throw new CustomException(new Error(Constant.CustomExceptions.DuplicateUser,1001), HttpStatusCode.InternalServerError);

            var userEntity = _mapper.Map<UserEntity>(userRegister);
            var hmac = new HMACSHA512();
            userEntity.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegister.Password));
            userEntity.HashKey = hmac.Key;

            var userGuid = await _userRepository.AddOrUpdateUser(userEntity);
            return userGuid;
        }

        private async Task<bool> IsUserExists(UserRegisterRequest userRegister)
        {
            var users = await _userRepository.GetUsers();
            var existingUser = users.Where(emp => emp.Email == userRegister.Email).FirstOrDefault();
            if (existingUser is not null)
                return true;
            return false;
        }

        public async Task UploadAsync(IFormFile formFile)
        {
            Guid fileName = Guid.NewGuid();
            await _blobStorageService.UploadAsync(fileName.ToString(), formFile);
        }
    }
}
