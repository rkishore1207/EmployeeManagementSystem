using DataAccessLayer.Helpers;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using System.Data;
using Utilities.ConfigService;

namespace DataAccessLayer.Repositories
{
    public class AdminRepository : BaseRepo, IAdminRepository
    {
        #region Constructor Declaration for Base Class
        public AdminRepository(IConfigurationService configurationService) : base(configurationService)
        {

        }
        #endregion

        /// <summary>
        /// Get all the Destinations from the Database
        /// </summary>
        /// <returns>List of designations contains Id, Name, DisplayName</returns>
        public async Task<List<ConfigEntity>> GetDesignations()
        {
            var designations = await ExecuteStoredProcedureAsync<ConfigEntity>("GetDesignations");
            return designations;
        }

        /// <summary>
        /// Insert the new Payslip Structure into the Payslip Table
        /// </summary>
        /// <param name="payslips"></param>
        public async Task SavePayslip(List<PayslipEntity> payslips)
        {
            using(DataTable table = DataTableHelper.GetPayslipDataTable(payslips))
            {
                await BulkInsert("[data].[Payslip]", table);
            }
        }
    }
}
