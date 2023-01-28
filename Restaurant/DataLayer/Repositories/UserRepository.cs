using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
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

        public IQueryable<User> GetAll()
        {
            return _context.Users.AsQueryable();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
