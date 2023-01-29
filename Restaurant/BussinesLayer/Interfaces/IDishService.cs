using BussinesLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IDishService : IService<DishRequestDto>
    {
        Task<List<DishRequestDto>> GetAll();
    }
}
