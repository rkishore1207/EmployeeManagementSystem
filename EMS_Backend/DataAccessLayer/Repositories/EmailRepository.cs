using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using System.Data;
using Utilities.ConfigService;

namespace DataAccessLayer.Repositories
{
    public class EmailRepository : BaseRepo, IEmailRepository
    {
        public EmailRepository(IConfigurationService configurationService) : base(configurationService)
        {

        }

        public async Task SaveEmailRequest(EmailEntity emailEntity)
        {
            List<SpParameter> spParameters = new List<SpParameter>()
            {
                SpParameter.Create("UserUID", emailEntity.UserUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                SpParameter.Create("ReceiverEmail", emailEntity.ReceiverEmail, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("Subject", emailEntity.Subject, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("EmailContent", emailEntity.EmailContent, ParameterDirection.Input, SqlDbType.NVarChar)
            };
            await ExecuteStoredProcedureNonQueryAsync("", spParameters.ToArray());
        }
    }
}
