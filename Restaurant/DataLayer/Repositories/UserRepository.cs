using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        #region CRUD operations
        public IQueryable<User> GetAll()
        {
            return _context.Users.AsQueryable();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task Add(User entity)
        {
            return _context.Users.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var user = await GetById(id);
            if (user is null)
            {
                throw new ObjectNotExistExepcion(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion

        public Task<User> CheckIdentity(string email, string password)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Password == password && x.Email == email);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }        
    }
}
