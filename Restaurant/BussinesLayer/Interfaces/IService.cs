namespace BussinesLayer.Interfaces
{
    public interface IService<TRequest>
    {
        Task<TRequest> GetById(Guid id);
        Task Update(Guid id, TRequest entity);
        Task Delete(Guid id);
    }
}
