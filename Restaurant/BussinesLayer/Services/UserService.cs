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

        public async Task<Tuple<int,DateTime>> ReservePlace(UserReserveDto entity)
        {
            var existUser = await _userRepository.GetAll()
                                                 .Where(x => x.Email == entity.Email)
                                                 .FirstOrDefaultAsync();

            //ОБРАБОТКА!!!
            //if (existUser is not null)
            //{
            //    throw new ObjectAlreadyExistExepcion(nameof(existUser));
            //}
            //ОБРАБОТКА!!!
            ;
            var place = await _placeRepository.GetAll()
                                              .Where(x => x.IsFree == true)
                                              .FirstOrDefaultAsync(x => x.CountOfSeats == entity.CountOfSeats);

            if (place is null)
            {
                throw new ObjectNotExistExepcion(nameof(place));
            }

            existUser.DateOfReservation = entity.DateOfReservation;
            existUser.Place = place;

            _userRepository.Update(existUser);
            await _userRepository.Save();

            return new (place.SeatNumber, entity.DateOfReservation);
        }


        public async Task<(int, DateTime)> GetPlace(Guid id)
        {
            var user = await _userRepository.GetById(id);
            var place = await _placeRepository.GetById(user.PlaceId.Value);

            return (place.SeatNumber, user.DateOfReservation.Value);
        }

        public async Task Register(UserDto entity)
        {
            var existUser = await _userRepository.GetAll()
                                             .Where(x => x.Email == entity.Email)
                                             .FirstOrDefaultAsync();

            //ОБРАБОТКА!!!
            if (existUser is not null)
            {
                throw new ObjectAlreadyExistExepcion(nameof(existUser));
            }
            //ОБРАБОТКА!!!

            var user = new User
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Password = entity.Password,
                Email = entity.Email
            };

            await _userRepository.Add(user);
            await _userRepository.Save();
        }

        public async Task<UserDto> CheckIdentity(string email, string password)
        {
            var user = await _userRepository.CheckIdentity(email, password);

            if (user is null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };

            return userDto;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user is null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };
            return userDto;
        }

        public Task<UserReserveDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, UserReserveDto entity)
        {
            throw new NotImplementedException();
        }

        Task<UserDto> IService<UserDto>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
