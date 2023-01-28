using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPlaceRepository placeRepository, IMapper mapper)
        {
            _placeRepository = placeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(UserRequestDto entity)
        {
            var existUser = await _userRepository.GetAll()
                                             .Where(x => x.FirstName == entity.FirstName
                                                      && x.LastName == entity.LastName)
                                             .FirstOrDefaultAsync();

            //ОБРАБОТКА!!!
            if (existUser is not null)
            {
                throw new ObjectAlreadyExistExepcion(nameof(existUser));
            }
            //ОБРАБОТКА!!!
  ;
            var place = await _placeRepository.GetAll()
                                              .Where(x => x.IsFree == true)
                                              .FirstOrDefaultAsync(x => x.CountOfSeats == entity.CountOfSeats);

            if (place is null)
            {
                throw new ObjectNotExistExepcion(nameof(place));
            }

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

            return place.SeatNumber;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRequestDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, UserRequestDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
