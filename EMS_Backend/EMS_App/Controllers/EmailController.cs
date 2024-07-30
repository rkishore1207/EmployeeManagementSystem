using BusinessLogics.Interfaces;
using BusinessLogics.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace EMS_App.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailProcessController _emailProcessController;

        public EmailController(IEmailProcessController emailProcessController)
        {
            _emailProcessController = emailProcessController;
        }

        [HttpPost]
        [Route("send")]
        public async Task<ActionResult> SendEmail(EmailRequest emailRequest)
        {
            await _emailProcessController.SendEmail(emailRequest);
            return Ok();
        }
    }
}
