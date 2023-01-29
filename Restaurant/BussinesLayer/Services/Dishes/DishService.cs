using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Dishes
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public Task<int> Add(DishRequestDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DishRequestDto>> GetAll()
        {
            var dishes = _dishRepository.GetAll().ToList();
            if (dishes.Count() == 0)
            {
                throw new ObjectNotExistExepcion(nameof(dishes));
            }
            
            var dishesDto = new List<DishRequestDto>();
            foreach (var dish in dishes)
            {
                dishesDto.Add(new DishRequestDto
                {
                    Id = dish.DishId,
                    Name = dish.Name,
                    Description = dish.Description,
                    Price = dish.Price,
                    ImageUrl = dish.ImageUrl
                });
            }
            return Task.FromResult(dishesDto);
        }

        public async Task<DishRequestDto> GetById(Guid id)
        {
            var dish = await _dishRepository.GetById(id);
            //обратобка ошибки
            var dishDto = new DishRequestDto
            {
                Id = dish.DishId,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                ImageUrl = dish.ImageUrl
            };

            return dishDto;
        }

        public Task Update(Guid id, DishRequestDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
