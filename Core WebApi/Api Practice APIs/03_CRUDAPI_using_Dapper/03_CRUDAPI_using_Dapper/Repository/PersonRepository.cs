
using _03_CRUDAPI_using_Dapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace _03_CRUDAPI_using_Dapper.Repository
{
    public class PersonRepository : IPersonRepository
    {
        /// A private field to hold the connection string
        private readonly string _ConnectionString;
      
        // Reason: Dependency Injection (DI) passes the connection string here
        // જેથી આ ક્લાસને ખબર પડે કે કયા ડેટાબેઝ સાથે કનેક્ટ થવું છે.
        public PersonRepository(IConfiguration config)
        {
            _ConnectionString = config.GetConnectionString("dapperConnString");
        }

        
        // Reason: Dapper requires an open IDbConnection to execute commands.
        private SqlConnection Connection() => new SqlConnection(_ConnectionString);
        //આ method _ConnectionString નો use કરીને નવી database connection બનાવે છે.જેના આધારે અમે Dapper queries run કરી શકીએ.



        public async Task<IEnumerable<Person>> GetAllAsync()
        {   
            using var conn = Connection();
            var sql = "select * from dbo.Person";
            return await conn.QueryAsync<Person>(sql);
            //sql holds the query //QueryAsync<Person>(sql) → sends query to DB //DB returns rows
            //Dapper maps rows → Person objects //Return List<Person>
        }

        public async Task<Person> GetById(int id)
        {
            using var conn = Connection();
            var sql = "SELECT * FROM Person WHERE Id = @id";
            return await conn.QueryFirstOrDefaultAsync<Person>(sql, new {id});
            // "new {id}"-->aa ek obje parameter trike use thy chhe. aa sql ma int id mathi je id aavse te id ne store krse ane slq ne aa parameter ma je id mli hse te moklse.
        }

        public async Task<int> Add(Person person)
        {
            using var conn = Connection();
            var sql = "insert into dbo.Person values (@Name, @Surname, @Age)";
            return await conn.ExecuteAsync(sql, person); //ahi aapne new keyword use etle no kryu bcz person already as a object pass thy 6 jyare new {id} ma id no pela obj bnavo pde.
        }

        public async Task<int> Edit(Person person)
        {
            using var conn = Connection();
            var sql = "Update dbo.Person set Name=@Name, Surname=@Surname, Age=@Age where Id = @Id";
            return await conn.ExecuteAsync(sql, person);
        }


        public async Task<int> Delete(int id)
        {
            using var conn = Connection();
            var sql = "Delete from Person where Id = @Id";
            return await conn.ExecuteAsync(sql, new {id});
        }
    }
}
