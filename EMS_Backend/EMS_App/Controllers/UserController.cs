using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProcessController _userProcessController;

        public UserController(IUserProcessController userProcessController)
        {
            _userProcessController = userProcessController;
        }

        [HttpPost]
        [Route("userLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequest userLogin) 
        {
            var user = await _userProcessController.UserLogin(userLogin);
            return Ok(user);
        }

        [HttpPost]
        [Route("userRegister")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterRequest userRegister)
        {
            var user = await _userProcessController.UserRegister(userRegister);
            return Ok(user);
        }
    }
}
