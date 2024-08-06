using EMS.DataAccessLayer.Models;

namespace EMS.DataAccessLayer.Interfaces
{
    public interface IPayslipRepository
    {
        Task<List<PayslipEntity>> GetPayslipByUserUID(Guid userUID);
    }
}