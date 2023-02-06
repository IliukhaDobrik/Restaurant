using BussinesLayer.Dtos;

namespace BussinesLayer.Interfaces
{
    public interface IDishService : IService<DishRequestDto>
    {
        Task<IReadOnlyCollection<DishRequestDto>> GetAll();
    }
}
