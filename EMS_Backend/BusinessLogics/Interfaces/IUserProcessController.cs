using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;

namespace BusinessLogics.Interfaces
{
    public interface IUserProcessController
    {
        Task<UserViewModel> UserLogin(UserLoginRequest userLogin);
        Task<Guid> UserRegister(UserRegisterRequest userRegister);
    }
}