using EMS.DataAccessLayer.Helpers;
using EMS.DataAccessLayer.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace EMS.BusinessLogics.Helpers
{
    public class EmailService
    {
        private readonly IHelper _helper;
        private readonly IEmailRepository _emailRepository;
        private readonly IConfiguration _configuration;

        public EmailService()
        {
            
        }

        public EmailService(IHelper helper, IEmailRepository emailRepository, IConfiguration configuration)
        {
            _helper = helper;
            _emailRepository = emailRepository;
            _configuration = configuration;
        }

        public string ReceiverEmail { get; set; }
        public Guid UserUID { get; set; }
        public string Subject { get; set; }
        public string EmailContent { get; set; }

        public async Task SendEmail(string email)
        {
            var user = await _helper.GetUserIdByEmail(email);
            UserUID = user.UID;
            await _emailRepository.SaveEmailRequest(UserUID,ReceiverEmail,Subject,EmailContent);
            var emailMessage = new MimeMessage();
            var from = _configuration["EmailSettings:From"];
            emailMessage.From.Add(new MailboxAddress("Kishore", from));
            emailMessage.To.Add(new MailboxAddress(ReceiverEmail, ReceiverEmail));
            emailMessage.Subject = Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(EmailContent)
            };

            using var client = new SmtpClient();
            try
            {
                client.Connect(_configuration["EmailSettings:SmtpServer"], 465, true);
                client.Authenticate(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
                client.Send(emailMessage);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
