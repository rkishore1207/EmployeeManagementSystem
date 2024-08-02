using EMS.DataAccessLayer.Models;
using EMS.DataAccessLayer.Repositories;
using EMS.Utilities.ConfigService;
using System.Data;

namespace EMS.DataAccessLayer.Helpers
{
    public class Helper : BaseRepo, IHelper
    {
        public Helper(IConfigurationService configurationService) : base(configurationService)
        {

        }

        public async Task<UserEntity> GetUserIdByEmail(string email)
        {
            var spEmail = SpParameter.Create("UserEmail", email, ParameterDirection.Input, SqlDbType.NVarChar);
            var user = await ExecuteStoredProcedureAsync<UserEntity>("GetUserByEmail", spEmail);
            return user.FirstOrDefault();
        }
    }
}
