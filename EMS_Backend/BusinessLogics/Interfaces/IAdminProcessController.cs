using BusinessLogics.Models.ViewModels;

namespace BusinessLogics.Interfaces
{
    public interface IAdminProcessController
    {
        Task<List<Employees>> GetUnApprovedEmployees();
    }
}