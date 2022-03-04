
namespace CrudApi.Services
{
    public interface IPersonService
    {
        Task CreatAsync(Person person);
        Task DeleteAsync(int id);
        Task<IList<Person>> GetAllAsync();
        Task<Person> GetAsync(int id);
        Task UpdateAsync(Person person);
    }
}