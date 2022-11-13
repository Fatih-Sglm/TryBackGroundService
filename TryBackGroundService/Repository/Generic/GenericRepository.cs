using TryBackGroundService.Context;

namespace TryBackGroundService.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public BaseDbContext Context { get; set; }

        public GenericRepository(BaseDbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(T entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }
    }
}
