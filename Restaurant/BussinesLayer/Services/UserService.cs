using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlaceRepository _placeRepository;

        public UserService(IUserRepository userRepository, IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto> Add(UserRequestDto entity)
        {
            //проверка на существование в таблие

            var place = await _placeRepository.GetAll()
                                              .Where(x => x.IsFree == true)
                                              .FirstOrDefaultAsync(x => x.CountOfSeats == entity.CountOfSeats);

            //if place == null

            var user = new User
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                DateOfReservation = entity.DateOfReservation,
                Place = place
            };
              
            await _userRepository.Add(user);
            await _userRepository.Save();

            //хуйня
            return new UserResponseDto();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> Update(Guid id, UserRequestDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
