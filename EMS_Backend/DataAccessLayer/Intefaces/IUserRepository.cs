﻿namespace DataAccessLayer.Intefaces
{
    public interface IUserRepository<T,K>
    {
        Task<T> GetUser(K userUID);
        Task<List<T>> GetUsers();
        Task AddUser(T user);
        Task DeleteUser(K userUID);
        Task<bool> UpdateUser(T user);
    }
}
