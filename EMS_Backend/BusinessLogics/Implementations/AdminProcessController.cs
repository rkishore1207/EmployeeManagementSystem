using AutoMapper;
using BusinessLogics.Interfaces;
using BusinessLogics.Models.ViewModels;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;

namespace BusinessLogics.Implementations
{
    public class AdminProcessController : IAdminProcessController
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository<UserEntity, Guid> _userRepository;
        private readonly IMapper _mapper;

        public AdminProcessController(IAdminRepository adminRepository, IUserRepository<UserEntity, Guid> userRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<Employees>> GetUnApprovedEmployees()
        {
            var employees = await _userRepository.GetUsers();
            var unApprovedUsers = employees.Where(employee => !employee.IsActive).ToList();
            var employeesView = _mapper.Map<List<Employees>>(unApprovedUsers);
            return employeesView;
        }
    }
}
