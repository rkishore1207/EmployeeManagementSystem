namespace DataAccessLayer.Intefaces
{
    public interface IUserRepository<T,K>
    {
        Task<T> GetUser(K userUID);
        Task<List<T>> GetUsers();
        Task<Guid> AddOrUpdateUser(T user);
        Task DeleteUser(K userUID);
    }
}
