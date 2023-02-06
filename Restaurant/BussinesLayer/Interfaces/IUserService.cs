using BussinesLayer.Dtos;

namespace BussinesLayer.Interfaces
{
    public interface IUserService : IService<UserRequestDto>
    {
        Task<UserRequestDto> CheckIdentity(string email, string password);
        Task<UserRequestDto> GetByEmail(string email);
        Task Register(UserRequestDto entity);
        Task<(int,DateTime)> ReservePlace(UserReserveDto entity);

        //get place by userId
        Task<(int, DateTime)> GetPlace(Guid userId);
    }
}
