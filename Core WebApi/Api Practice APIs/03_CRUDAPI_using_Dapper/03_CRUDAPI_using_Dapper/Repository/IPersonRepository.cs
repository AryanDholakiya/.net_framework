using _03_CRUDAPI_using_Dapper.Models;
namespace _03_CRUDAPI_using_Dapper.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        //returns List of all persons //Task<> because method is async.//IEnumerable<Person> → many records (list)
        Task<Person> GetById(int id);
        //returns one person, where person.Id == given ID
        Task<int> Add(Person person);
        Task<int> Edit(Person person);
        Task<int> Delete(int id);
    }
}
