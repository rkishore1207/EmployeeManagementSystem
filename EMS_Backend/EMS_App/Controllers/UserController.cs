using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    [Route("api/user")]
    [ApiController]
    [EnableCors("ReactCORS")]
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

        [HttpPost]
        [Route("uploadImage")]
        public async Task<IActionResult> Upload()
        {
            var httpContext = HttpContext.Request;
            var inputFile = httpContext.Form.Files[0];
            if (inputFile.FileName.EndsWith("jpeg") || inputFile.FileName.EndsWith("jpg") || inputFile.FileName.EndsWith("png"))
            {
                await _userProcessController.UploadAsync(inputFile);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
