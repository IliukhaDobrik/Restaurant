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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly MyDbContext _context;

        public PlaceRepository(MyDbContext context)
        {
            _context = context;
        }
        public Task Add(Place entity)
        {
            return _context.Places.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var place = await GetById(id);
            if (place is null)
            {
                throw new ObjectNotExist(nameof(place));
            }
            _context.Places.Remove(place);
        }

        public IQueryable<Place> GetAll()
        {
            return _context.Places.AsQueryable();
        }

        public async Task<Place> GetById(Guid id)
        {
            return await _context.Places.FindAsync(id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Guid id, Place entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
