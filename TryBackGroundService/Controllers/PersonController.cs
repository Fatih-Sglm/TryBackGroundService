using Microsoft.AspNetCore.Mvc;
using TryBackGroundService.Models;
using TryBackGroundService.Services.PersonService;

namespace TryBackGroundService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddPersonModel person)
        {
            await _personService.AddPerson(person);
            return Created("Created", person);
        }
    }
}
