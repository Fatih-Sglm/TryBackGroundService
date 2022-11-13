using TryBackGroundService.Models;

namespace TryBackGroundService.Services.PersonService
{
    public interface IPersonService
    {
        Task AddPerson(AddPersonModel person);
    }
}
