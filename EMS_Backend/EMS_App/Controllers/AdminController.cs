using BusinessLogics.Authorization;
using BusinessLogics.Interfaces;
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

        [HttpGet]
        [Route("employees")]
        public async Task<ActionResult> GetEmployees()
        {
            var employees = await _adminProcessController.GetUnApprovedEmployees();
            return Ok(employees);
        }
    }
}
