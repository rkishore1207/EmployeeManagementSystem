
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System.Data;
using Utilities.ConfigService;

namespace BusinessLogics.Helper
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
