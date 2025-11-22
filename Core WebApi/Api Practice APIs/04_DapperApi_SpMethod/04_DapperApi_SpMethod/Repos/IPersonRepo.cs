using _04_DapperApi_SpMethod.Models;
namespace _04_DapperApi_SpMethod.Repos
{
    public interface IPersonRepo
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<int> Add(Person person);
        Task<int> Edit(Person person);
        Task<int> Delete(int id);
    }
}
