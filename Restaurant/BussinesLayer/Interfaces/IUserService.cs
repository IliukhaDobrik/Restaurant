using BussinesLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        Task<UserDto> CheckIdentity(string email, string password);
        Task<UserDto> GetByEmail(string email);
        Task Register(UserDto entity);
        Task<int> ReservePlace(UserReserveDto entity);
    }
}
