using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UserDishRepository : IUserDishRepository
    {
        private readonly MyDbContext _context;

        public UserDishRepository(MyDbContext context)
        {
            _context = context;
        }

        #region CRUD operations
        public IQueryable<UserDishes> GetAll()
        {
            return _context.Basket.AsQueryable();
        }

        public async Task<UserDishes> GetById(Guid id)
        {
            return await _context.Basket.FindAsync(id);
        }

        public Task Add(UserDishes entity)
        {
            return _context.Basket.AddAsync(entity).AsTask();
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

        public void Update(UserDishes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
