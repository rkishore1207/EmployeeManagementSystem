using BusinessLogics.Authorization;
using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [TypeFilter(typeof(AuthorizationFilter))]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminProcessController _adminProcessController;

        public AdminController(IAdminProcessController adminProcessController)
        {
            _adminProcessController = adminProcessController;
        }

        /// <summary>
        /// Get all the Unapproved Employees
        /// </summary>        
        /// <returns>List of Unapproved employees</returns>
        [HttpGet]
        [Route("unApprovedEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            var employees = await _adminProcessController.GetUnApprovedEmployees();
            return Ok(employees);
        }

        /// <summary>
        /// Get all the Designations in an Organization
        /// </summary>
        /// <returns>List of Designations</returns>
        [HttpGet]
        [Route("getDesignations")]
        public async Task<ActionResult> GetDesignations()
        {
            var designations = await _adminProcessController.GetDesignations();
            return Ok(designations);
        }

        /// <summary>
        /// Save the Payslip structure for the particular Designation
        /// </summary>
        /// <param name="requests">list of Allowance,Designation,AllowanceType and Price</param>
        /// <returns></returns>
        [HttpPost]
        [Route("savePayslip")]
        public async Task SavePayslip(List<PayslipRequest> requests)
        {
            await _adminProcessController.SavePayslip(requests);
        }

        /// <summary>
        /// Get all the managers by Current Employee's Designation Id
        /// </summary>
        /// <param name="designationId">Current Employee's Designation</param>
        /// <returns>All the Managers</returns>
        [HttpGet]
        [Route("getManagers/{designationId}")]
        public async Task<ActionResult> GetManagers(int designationId)
        {
            var managers = await _adminProcessController.GetManagersByDesignation(designationId);
            return Ok(managers);
        }
    }
}
