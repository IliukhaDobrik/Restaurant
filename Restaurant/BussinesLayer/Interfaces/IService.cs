using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IService<TRequest>
    {
        //Task<IReadOnlyCollection<TResponse>> GetAll();
        Task<TRequest> GetById(Guid id);
        //Task<int> Add(TRequest entity);
        Task Update(Guid id, TRequest entity);
        Task Delete(Guid id);
    }
}
