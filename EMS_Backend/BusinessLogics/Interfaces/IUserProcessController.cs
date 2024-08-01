using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BusinessLogics.Interfaces
{
    public interface IUserProcessController
    {
        Task<UserViewModel> UserLogin(UserLoginRequest userLogin);
        Task<Guid> UserRegister(UserRegisterRequest userRegister);
        Task UploadAsync(IFormFile formFile);
    }
}