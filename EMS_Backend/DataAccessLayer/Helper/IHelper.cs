
namespace BusinessLogics.Helper
{
    public interface IHelper
    {
        Task<Guid> GetUserIdByEmail(string email);
    }
}