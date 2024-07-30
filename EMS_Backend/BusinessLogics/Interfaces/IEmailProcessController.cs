using BusinessLogics.Models.RequestModels;

namespace BusinessLogics.Interfaces
{
    public interface IEmailProcessController
    {
        Task SendEmail(EmailRequest emailRequest);
    }
}