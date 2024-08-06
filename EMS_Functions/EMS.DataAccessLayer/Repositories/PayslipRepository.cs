using EMS.DataAccessLayer.Interfaces;
using EMS.DataAccessLayer.Models;
using EMS.Utilities.ConfigService;
using System.Data;

namespace EMS.DataAccessLayer.Repositories
{
    public class PayslipRepository : BaseRepo, IPayslipRepository
    {
        public PayslipRepository(IConfigurationService configurationService) : base(configurationService)
        {
        }

        public async Task<List<PayslipEntity>> GetPayslipByUserUID(Guid userUID)
        {
            var spUserUID = SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier);
            var payslips = await ExecuteStoredProcedureAsync<PayslipEntity>("GetPayslipByUser", spUserUID);
            return payslips;
        }
    }
}
