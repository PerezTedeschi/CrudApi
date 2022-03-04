using CrudApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
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

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return Ok(await _personService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> Get(int id)
        {
            var person = await _personService.GetAsync(id);

            return person is not null ? Ok(person) : NotFound(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> Post(Person person)
        {
            await _personService.CreatAsync(person);

            return Ok(await _personService.GetAllAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> Put(Person person)
        {
            await _personService.UpdateAsync(person);

            return Ok(await _personService.GetAllAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> Delete(int id)
        {
            await _personService.DeleteAsync(id);

            return Ok(await _personService.GetAllAsync());
        }
    }
}
