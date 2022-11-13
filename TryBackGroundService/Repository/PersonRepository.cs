using TryBackGroundService.Context;
using TryBackGroundService.Entities;
using TryBackGroundService.Repository.Generic;

namespace TryBackGroundService.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
