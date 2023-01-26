using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IService<TRequest, TResponse>
    {
        //Task<IReadOnlyCollection<TResponse>> GetAll();
        //Task<TResponse> GetById(Guid id);
        Task<TResponse> Add(TRequest entity);
        Task<TResponse> Update(Guid id, TRequest entity);
        Task Delete(Guid id);
    }
}
