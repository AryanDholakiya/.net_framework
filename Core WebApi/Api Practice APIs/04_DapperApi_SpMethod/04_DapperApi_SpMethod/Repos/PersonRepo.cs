using _04_DapperApi_SpMethod.Models;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace _04_DapperApi_SpMethod.Repos
{
    public class PersonRepo : IPersonRepo
    {
        private readonly string _ConnectionString;

        public PersonRepo(IConfiguration config)
        {
            _ConnectionString = config.GetConnectionString("DapperApiUsinSp");
        }

        private SqlConnection Connection() => new SqlConnection(_ConnectionString);

        public async Task<IEnumerable<Person>> GetAll()
        {
            using var conn = Connection();
            return await conn.QueryAsync<Person>(
                "sp_GetAll",
                commandType: System.Data.CommandType.StoredProcedure
                );
            //conn.QueryAsync<Person> આ Dapper extension method છે. tyathi dapper call thy 6.
            //Dapper કનેક્શન (con) નો ઉપયોગ કરીને SQL Server ને સંદેશ મોકલે છે: "Hey Server, sp_GetAll નામની SP ને ચલાવો."
            //again sp mathi data Dapper ma aavse ane return thse controller ma jya thi GetAll method fire thyeli
        }

        public async Task<Person> GetById(int id)
        {
            using var conn = Connection();
            return await conn.QueryFirstAsync<Person>(
                "sp_GetPersonById",
                new { PersonId = id }, //PersonId e sp @name sathe same hovu joie
                commandType: System.Data.CommandType.StoredProcedure
                );
        }

        public async Task<int> Add(Person person)
        {
            using var conn = Connection();
            return await conn.ExecuteAsync(
                "sp_AddPerson",
                new { person.Name, person.Surname, person.Age },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }

        public async Task<int> Edit(Person person)
        {
            using var conn = Connection();
            return await conn.ExecuteAsync(
                "sp_EditPerson",
                new { person.Id, person.Name, person.Surname, person.Age },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }

        public async Task<int> Delete(int id)
        {
            using var conn = Connection();
            return await conn.ExecuteAsync(
                "sp_DeletePerson",
                new { Id = id }
                );
        }
    }
}
