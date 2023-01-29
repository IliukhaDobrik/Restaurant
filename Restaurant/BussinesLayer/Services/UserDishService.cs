using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Repositories.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class UserDishService : IUserDishService
    {
        private readonly IUserDishRepository _userDishRepository;
        private readonly IDishService _dishService;
        private readonly IUserService _userService;

        public UserDishService(IUserDishRepository userDishRepository, IDishService dishService, IUserService userService)
        {
            _dishService = dishService;
            _userDishRepository = userDishRepository;
            _userService = userService;
        }

        public async Task Add(UserDishDto userDishDto)
        {
            var userDto = await _userService.GetByEmail(userDishDto.UserEmail);

            await _userDishRepository.Add(new UserDishes
            {
                UserId = userDto.UserId,
                DishId = userDishDto.DishId
            });
            await _userDishRepository.Save();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DishRequestDto>> GetById(Guid id)
        {
            var users = await _userDishRepository.GetAll().Where(x => x.UserId == id).ToListAsync();
            var dishes = new List<DishRequestDto>();

            foreach (var user in users)
            {
                var dishId = new Guid(user.DishId.ToString());
                dishes.Add(await _dishService.GetById(dishId));
            }

            return dishes;
        }

        public Task Update(Guid id, UserDishDto entity)
        {
            throw new NotImplementedException();
        }

        Task<UserDishDto> IService<UserDishDto>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
