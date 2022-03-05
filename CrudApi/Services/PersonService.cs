using CrudApi.Data;
using CrudApi.Exceptions;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _dataContext;

        public PersonService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IList<Person>> GetAllAsync()
        {
            return await _dataContext.People.ToListAsync();
        }

        public async Task<Person> GetAsync(int id)
        {
            var person = await _dataContext.People.FindAsync(id);

            if (person == null) throw new NotFoundExecption("Person not found.");

            return person;
        }

        public async Task CreatAsync(Person person)
        {
            _dataContext.Add(person);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            var personToUpdate = await _dataContext.People.FindAsync(person.Id);

            if (personToUpdate == null) throw new NotFoundExecption("Person not found.");

            personToUpdate.Name = person.Name;
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.Place = person.Place;

            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var personToDelete = await _dataContext.People.FindAsync(id);

            if (personToDelete == null) throw new NotFoundExecption("Person not found.");

            _dataContext.Remove(personToDelete);
            await _dataContext.SaveChangesAsync();
        }
    }
}
