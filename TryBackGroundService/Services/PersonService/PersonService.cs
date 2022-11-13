using TryBackGroundService.Entities;
using TryBackGroundService.Models;
using TryBackGroundService.QueueServices;

namespace TryBackGroundService.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IQueueService<Person> _queueService;

        public PersonService(IQueueService<Person> queueService)
        {
            _queueService = queueService;
        }

        //Bu metod ile bize gelen veriyi person a çevirip Queue ye ekliyoruz 
        public async Task AddPerson(AddPersonModel person)
        {
            await _queueService.AddQueue(new Person()
            {
                Name = person.Name,
                DepartmentId = person.DepartmandId
            });
        }
    }
}
