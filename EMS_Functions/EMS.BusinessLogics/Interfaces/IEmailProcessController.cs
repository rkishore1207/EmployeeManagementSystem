using EMS.BusinessLogics.Models;

namespace EMS.BusinessLogics.Interfaces
{
    public interface IEmailProcessController
    {
        Task ResetPasswordEmail(Email email);
    }
}