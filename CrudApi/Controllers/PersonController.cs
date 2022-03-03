using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PersonController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }   

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return Ok(await _dataContext.People.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> Get(int id)
        {
            var person = await _dataContext.People.FindAsync(id);

            return person is not null ? Ok(person) : NotFound(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> Post(Person person)
        {
            _dataContext.Add(person);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.People.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> Put(Person request)
        {
            var person = await _dataContext.People.FindAsync(request.Id);

            if (person is null) return NotFound(person);

            person.Name = request.Name;
            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Place = request.Place;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.People.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> Delete(int id)
        {
            var person = await _dataContext.People.FindAsync(id);

            if (person is null) return NotFound(person);

            _dataContext.Remove(person);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.People.ToListAsync());
        }
    }
}
