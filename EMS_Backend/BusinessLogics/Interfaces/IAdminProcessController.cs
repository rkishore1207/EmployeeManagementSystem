using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;

namespace BusinessLogics.Interfaces
{
    public interface IAdminProcessController
    {
        Task<List<Employees>> GetUnApprovedEmployees();
        Task<List<ConfigView>> GetDesignations();
        Task SavePayslip(List<PayslipRequest> requests);
        Task<List<Employees>> GetManagersByDesignation(int designationId);
    }
}