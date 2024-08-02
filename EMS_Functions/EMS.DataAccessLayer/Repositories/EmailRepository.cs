using EMS.DataAccessLayer.Interfaces;
using EMS.DataAccessLayer.Models;
using EMS.Utilities.ConfigService;
using System.Data;

namespace EMS.DataAccessLayer.Repositories
{
    public class EmailRepository : BaseRepo, IEmailRepository
    {
        public EmailRepository(IConfigurationService configurationService) : base(configurationService)
        {

        }

        public async Task SaveEmailRequest(Guid userUID, string email, string subject, string content)
        {
            List<SpParameter> spParameters = new List<SpParameter>()
            {
                SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                SpParameter.Create("ReceiverEmail", email, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("Subject", subject, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("EmailContent", content, ParameterDirection.Input, SqlDbType.NVarChar)
            };
            await ExecuteStoredProcedureNonQueryAsync("", spParameters.ToArray());
        }
    }
}
