
using DataAccessLayer.Models;

namespace DataAccessLayer.Intefaces
{
    public interface IAdminRepository
    {
        Task<List<DesignationEntity>> GetDesignations();
        Task SavePayslip(List<PayslipEntity> payslips);
        Task<List<UserEntity>> GetManagersByLevel(int level);
    }
}