using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserDishRepository : IUserDishRepository
    {
        private readonly MyDbContext _context;

        public UserDishRepository(MyDbContext context)
        {
            _context = context;
        }

        public  Task Add(UserDishes entity)
        {
            return _context.UserDishes.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var userDish = await GetById(id);
            if (userDish is null)
            {
                throw new ObjectNotExistExepcion(nameof(userDish));
            }
            _context.Remove(userDish);
        }

        public IQueryable<UserDishes> GetAll()
        {
            return _context.UserDishes.AsQueryable();
        }

        public async Task<UserDishes> GetById(Guid id)
        {
            return await _context.UserDishes.FindAsync(id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(UserDishes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
