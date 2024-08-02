using EMS.BusinessLogics.Helpers;
using EMS.BusinessLogics.Interfaces;
using EMS.BusinessLogics.Models;

namespace EMS.BusinessLogics.Implementations
{
    public class EmailProcessController : IEmailProcessController
    {
        public EmailProcessController()
        {

        }

        public async Task ResetPasswordEmail(Email email)
        {
            EmailService emailService = new EmailService();
            emailService.ReceiverEmail = email.EmployeeEmail;
            emailService.Subject = "Reset Password";
            var emailToken = new Random().Next(1, 20000).ToString();
            emailService.EmailContent = EmailContents.GetResetPasswordContents(email.EmployeeEmail, emailToken);
            await emailService.SendEmail(email.EmployeeEmail);
        }
    }
}
