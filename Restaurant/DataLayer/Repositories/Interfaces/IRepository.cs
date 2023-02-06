namespace DataLayer.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        Task Delete(Guid id);
        Task Save();
    }
}
