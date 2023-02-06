using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task Add(UserDishRequestDto userDishDto)
        {
            var userDto = await _userService.GetByEmail(userDishDto.UserEmail);
            await _userDishRepository.Add(new UserDishes
            {
                UserId = userDto.UserId,
                DishId = userDishDto.DishId
            });
            await _userDishRepository.Save();
        }

        public async Task Delete(Guid dishId)
        {
            var usersDish = await _userDishRepository.GetAll()
                                                     .FirstOrDefaultAsync(x => x.DishId == dishId);
            await _userDishRepository.Delete(usersDish.UserDishesId);
            await _userDishRepository.Save();
        }

        //get all user dishes by userId
        public async Task<IReadOnlyCollection<DishRequestDto>> GetById(Guid userId)
        {
            var users = await _userDishRepository.GetAll().Where(x => x.UserId == userId).ToListAsync();
            var dishes = users.Select(q => _dishService.GetById(q.DishId.Value).Result).ToList();
            return dishes;
        }

        #region NonImplement
        public Task Update(Guid id, UserDishRequestDto entity)
        {
            throw new NotImplementedException();
        }

        Task<UserDishRequestDto> IService<UserDishRequestDto>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
