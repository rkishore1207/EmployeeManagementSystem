
using DataAccessLayer.Models;

namespace DataAccessLayer.Intefaces
{
    public interface IAdminRepository
    {
        Task<List<ConfigEntity>> GetDesignations();
        Task SavePayslip(List<PayslipEntity> payslips);
    }
}