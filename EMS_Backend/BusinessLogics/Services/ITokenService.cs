using BusinessLogics.Models.ViewModels;

namespace Services.Implementations
{
    public interface ITokenService
    {
        string GenerateToken(UserViewModel user);
    }
}