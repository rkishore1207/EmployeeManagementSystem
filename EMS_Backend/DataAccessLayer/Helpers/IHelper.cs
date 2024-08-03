
using DataAccessLayer.Models;

namespace BusinessLogics.Helper
{
    public interface IHelper
    {
        Task<UserEntity> GetUserIdByEmail(string email);
    }
}