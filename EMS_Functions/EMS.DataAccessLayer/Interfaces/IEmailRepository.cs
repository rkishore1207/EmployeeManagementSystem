using EMS.DataAccessLayer.Models;

namespace EMS.DataAccessLayer.Interfaces
{
    public interface IEmailRepository
    {
        Task SaveEmailRequest(Guid userUID, string email, string subject, string content);
    }
}
