using AutoMapper;
using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using System.Net;
using Utilities.Constants;
using Utilities.Exceptions;

namespace BusinessLogics.Implementations
{
    public class AdminProcessController : IAdminProcessController
    {
        #region ReadOnly Dependencies
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository<UserEntity, Guid> _userRepository;
        private readonly IMapper _mapper;
        #endregion

        public AdminProcessController(IAdminRepository adminRepository, IUserRepository<UserEntity, Guid> userRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all the UnApproved Employees (those are InActive)
        /// </summary>
        /// <returns>List of Employees</returns>
        /// <exception cref="CustomException">Returns Empty, when No Users are Registered</exception>
        public async Task<List<Employees>> GetUnApprovedEmployees()
        {
            var employees = await _userRepository.GetUsers();
            if (!employees.Any())
                throw new CustomException(new Error(Constant.CustomExceptions.NoUsersWereRegistered,1003),HttpStatusCode.NotFound);
            var unApprovedUsers = employees.Where(employee => !employee.IsActive).ToList();
            var employeesView = _mapper.Map<List<Employees>>(unApprovedUsers);
            return employeesView;
        }

        /// <summary>
        /// Get all Designations from config table
        /// </summary>
        /// <returns>List of Designations</returns>
        public async Task<List<ConfigView>> GetDesignations()
        {
            var designations = await _adminRepository.GetDesignations();
            return _mapper.Map<List<ConfigView>>(designations);
        }

        /// <summary>
        /// Insert the Payslip into table
        /// </summary>
        /// <param name="requests"></param>
        public async Task SavePayslip(List<PayslipRequest> requests)
        {
            var payslipEntities = _mapper.Map<List<PayslipEntity>>(requests);
            await _adminRepository.SavePayslip(payslipEntities);
        }
    }
}
