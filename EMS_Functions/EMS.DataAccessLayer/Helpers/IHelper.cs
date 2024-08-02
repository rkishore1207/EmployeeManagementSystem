using EMS.DataAccessLayer.Models;

namespace EMS.DataAccessLayer.Helpers
{
    public interface IHelper
    {
        Task<UserEntity> GetUserIdByEmail(string email);
    }
}
