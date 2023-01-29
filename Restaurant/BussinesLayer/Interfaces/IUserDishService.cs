using BussinesLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IUserDishService : IService<UserDishDto>
    {
        Task<List<DishRequestDto>> GetById(Guid id);
        Task Add(UserDishDto userDto);
    }
}
