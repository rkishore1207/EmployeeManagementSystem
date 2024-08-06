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
        public async Task<List<DesignationEntity>> GetDesignations()
        {
            var designations = await ExecuteStoredProcedureAsync<DesignationEntity>("GetDesignations");
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

        /// <summary>
        /// Get the Managers based on the current Employee's level
        /// </summary>
        /// <param name="level">Level of current Employee</param>
        /// <returns>List of Managers</returns>
        public async Task<List<UserEntity>> GetManagersByLevel(int level)
        {
            var spLevel = SpParameter.Create("Level", level, ParameterDirection.Input, SqlDbType.Int);
            var users = await ExecuteStoredProcedureAsync<UserEntity>("GetManagersByDesignation",spLevel);
            return users;
        }
    }
}
