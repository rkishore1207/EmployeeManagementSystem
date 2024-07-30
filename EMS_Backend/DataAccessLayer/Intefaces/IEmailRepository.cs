using DataAccessLayer.Models;

namespace DataAccessLayer.Intefaces
{
    public interface IEmailRepository
    {
        Task SaveEmailRequest(EmailEntity emailEntity);
    }
}