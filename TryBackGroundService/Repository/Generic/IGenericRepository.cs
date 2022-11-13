namespace TryBackGroundService.Repository.Generic
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T entity);
    }
}
