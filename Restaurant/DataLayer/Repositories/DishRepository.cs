using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly MyDbContext _context;

        public DishRepository(MyDbContext context)
        {
            _context = context;
        }

        #region CRUD operations
        public IQueryable<Dish> GetAll()
        {
            return _context.Menu.AsQueryable();
        }

        public async Task<Dish> GetById(Guid id)
        {
            return await _context.Menu.FindAsync(id);
        }

        public Task Add(Dish entity)
        {
            return _context.Menu.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var dish = await GetById(id);
            if (dish is null)
            {
                throw new ObjectNotExistExepcion(nameof(dish));
            }
            _context.Menu.Remove(dish);
        }

        public void Update(Dish entity)
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
