using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BussinesLayer.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public DishService(IDishRepository dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<DishRequestDto>> GetAll()
        {
            var dishes = await _dishRepository.GetAll().ToListAsync();
            if (dishes.Count() == 0)
            {
                throw new ObjectNotExistExepcion(nameof(dishes));
            }
            var dishesDto = dishes.Select(q => _mapper.Map<DishRequestDto>(q)).ToList();
;
            return dishesDto;
        }

        public async Task<DishRequestDto> GetById(Guid id)
        {
            var dish = await _dishRepository.GetById(id);
            var dishDto = _mapper.Map<DishRequestDto>(dish);
            return dishDto;
        }

        #region NonImplement
        public Task Update(Guid id, DishRequestDto entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> Add(DishRequestDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
