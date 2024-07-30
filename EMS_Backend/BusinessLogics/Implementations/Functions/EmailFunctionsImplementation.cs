
using AutoMapper;
using BusinessLogics.Helper;
using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;
using DataAccessLayer.Models;
using Utilities.Constants;

namespace BusinessLogics.Implementations.Functions
{
    public class EmailFunctionsImplementation
    {
        private readonly IHelper _helper;
        private readonly IMapper _mapper;

        public EmailFunctionsImplementation(IHelper helper, IMapper mapper)
        {
            _helper = helper;
            _mapper = mapper;
        }

        public async Task SendEmail(EmailDetails emailDetails)
        {
            var user = await _helper.GetUserIdByEmail(emailDetails.ReceiverEmail);
            var emailEntity = _mapper.Map<EmailEntity>(emailDetails);
            emailEntity.Subject = Constant.Email.EmailSubject;
            var emailToken = new Random().Next(1, 2000).ToString();
            var tokenExpiry = DateTime.Now.AddMinutes(5);
            emailEntity.EmailContent = GetEmailContent(emailDetails.ReceiverEmail, emailToken);
        }

        private string GetEmailContent(string? email, string emailToken)
        {
            return $@"
                <!DOCTYPE html>
            <html>
            <head>
                <title>Password Reset</title>
            </head>
            <body style=""font-family: Arial, sans-serif; background-color: #f7f7f7;"">
                <div style=""max-width: 600px; margin: 0 auto; padding: 20px;"">
                    <h2>Password Reset</h2>
                    <p>Hello,</p>
                    <p>We have received a request to reset your password.Kindly Click the link below to reset your password:</p>
                    <p>
                        <a <a href=""http://localhost:3000/resetPassword/{email}/{emailToken}"" style=""display: inline-block; background-color: #007bff; color: #fff; text-decoration: none; padding: 10px 20px; border-radius: 5px;"">Reset Password</a>
                    </p>
                    <p>If you didn't request a password reset, please ignore this email. Your password will remain unchanged.</p>
                    <p>Best regards,<br>Kanini Loan Product</p>
                </div>
            </body>
            </html>";
        }
    }
}
