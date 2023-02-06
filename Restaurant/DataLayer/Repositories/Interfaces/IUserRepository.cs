using Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> CheckIdentity(string email, string password);
        Task<User> GetByEmail(string email);
    }
}
