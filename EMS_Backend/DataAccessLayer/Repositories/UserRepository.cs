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

        public async Task<Guid> AddOrUpdateUser(UserEntity user)
        {
            Guid UserUID = Guid.NewGuid();
            List<SpParameter> spParameters = new List<SpParameter>()
            {
                SpParameter.Create("UID", UserUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                SpParameter.Create("FirstName", user.FirstName, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("LastName", user.LastName, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("Email", user.Email, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("EmployeeID", user.EmployeeID, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("Address", user.Address, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("PhoneNumber", user.PhoneNumber, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("UserRole", user.UserRole, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("Designation", user.Designation, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("IsActive", user.IsActive, ParameterDirection.Input, SqlDbType.Bit),
                SpParameter.Create("DateOfBirth", user.DateOfBirth, ParameterDirection.Input, SqlDbType.DateTime),
                SpParameter.Create("DateOfJoin", user.DateOfJoin, ParameterDirection.Input, SqlDbType.DateTime),
                SpParameter.Create("ManagerUID", user.ManagerUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                SpParameter.Create("Location", user.Location, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("MaritalStatus", user.MaritalStatus, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("Age", user.Age, ParameterDirection.Input, SqlDbType.Int),
                SpParameter.Create("Gender", user.Gender, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("BloodGroup", user.BloodGroup, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("EmergencyNumber", user.EmergencyNumber, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("About", user.About, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("CreatedBy", UserUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier),
                SpParameter.Create("School", user.School, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("College", user.College, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("PreviousCompany", user.PreviousCompany, ParameterDirection.Input, SqlDbType.NVarChar),
                SpParameter.Create("PrivilegeLeave", user.PrivilegeLeave, ParameterDirection.Input, SqlDbType.Int),
                SpParameter.Create("WellnessLeave", user.WellnessLeave, ParameterDirection.Input, SqlDbType.Int),
                SpParameter.Create("EarnedLeave", user.EarnedLeave, ParameterDirection.Input, SqlDbType.Int),
                SpParameter.Create("CompOff", user.CompOff, ParameterDirection.Input, SqlDbType.Int),
                SpParameter.Create("OptionalLeave", user.OptionalLeave, ParameterDirection.Input, SqlDbType.Int),
                SpParameter.Create("LossOfPay", user.LossOfPay, ParameterDirection.Input, SqlDbType.Int),
                SpParameter.Create("PasswordHash", user.PasswordHash, ParameterDirection.Input, SqlDbType.Binary),
                SpParameter.Create("HashKey", user.HashKey, ParameterDirection.Input, SqlDbType.Binary)
            };
            await ExecuteStoredProcedureNonQueryAsync("AddOrUpdateUser", spParameters.ToArray());
            return UserUID;
        }

        public Task DeleteUser(Guid userUID)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetUser(Guid userUID)
        {
            var spUserUID = SpParameter.Create("UserUID", userUID, ParameterDirection.Input, SqlDbType.UniqueIdentifier);
            var user = await ExecuteStoredProcedureAsync<UserEntity>("GetUserByUID", spUserUID);
            if(user != null)
                return user.First();
            return UserEntity.Instance;
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            var users = await ExecuteStoredProcedureAsync<UserEntity>("GetUsers");
            return users.ToList();
        }
    }
}
