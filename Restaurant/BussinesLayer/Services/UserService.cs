using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BussinesLayer.Services
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

        public async Task<(int,DateTime)> ReservePlace(UserReserveDto entity)
        {
            var existUser = await _userRepository.GetByEmail(entity.Email);
            var place = await _placeRepository.GetAll()
                                              .Where(x => x.UserId == null)
                                              .FirstOrDefaultAsync(x => x.CountOfSeats == entity.CountOfSeats);

            if (place is null)
            {
                throw new ObjectNotExistExepcion(nameof(place));
            }

            place.DateOfReservation = entity.DateOfReservation;
            _placeRepository.Update(place);
            await _placeRepository.Save();

            existUser.Place = place;
            _userRepository.Update(existUser);
            await _userRepository.Save();

            return (place.SeatNumber, entity.DateOfReservation);
        }

        //get place by userId
        public async Task<(int, DateTime)> GetPlace(Guid userId)
        {
            var user = await _userRepository.GetById(userId);
            var place = await _placeRepository.GetAll()
                                              .FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (place is null)
            {
                throw new NullReferenceException(nameof(place));
            }

            return (place.SeatNumber, place.DateOfReservation.Value);
        }

        public async Task Register(UserRequestDto entity)
        {
            var existUser = await _userRepository.GetByEmail(entity.Email);

            if (existUser is not null)
            {
                throw new ObjectAlreadyExistExepcion(nameof(existUser));
            }

            var user = _mapper.Map<User>(entity);

            await _userRepository.Add(user);
            await _userRepository.Save();
        }

        public async Task<UserRequestDto> CheckIdentity(string email, string password)
        {
            var user = await _userRepository.CheckIdentity(email, password);

            if (user is null)
            {
                return null;
            }

            var userDto = _mapper.Map<UserRequestDto>(user);

            return userDto;
        }

        public async Task<UserRequestDto> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user is null)
            {
                return null;
            }

            var userDto = _mapper.Map<UserRequestDto>(user);
            return userDto;
        }

        #region NonImplement
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, UserRequestDto entity)
        {
            throw new NotImplementedException();
        }

        Task<UserRequestDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<UserRequestDto> IService<UserRequestDto>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
