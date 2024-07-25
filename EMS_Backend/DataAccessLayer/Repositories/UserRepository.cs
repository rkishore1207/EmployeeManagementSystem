using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using System.Data;
using Utilities.ConfigService;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepo, IUserRepository<UserEntity,Guid>
    {
        private readonly IConfigurationService _configurationService;
        public UserRepository(IConfigurationService configurationService) : base(configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task AddUser(UserEntity user)
        {
            List<SpParameter> spParameters = new List<SpParameter>()
            {
                //SpParameter.Create("FirstName", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                //SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier)
            };
            await ExecuteStoredProcedureNonQueryAsync("", spParameters.ToArray());
        }

        public Task DeleteUser(Guid userUID)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetUser(Guid userUID)
        {
            var spUserUID = SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier);
            var user = await ExecuteStoredProcedureAsync<UserEntity>("", spUserUID);
            if(user != null)
                return user.First();
            return UserEntity.Instance;
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            var users = await ExecuteStoredProcedureAsync<UserEntity>("");
            return users.ToList();
        }

        public Task<bool> UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
