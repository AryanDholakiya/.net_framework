using _2_Employee_Crud_using_Database.Models;
using Microsoft.EntityFrameworkCore;

namespace _2_Employee_Crud_using_Database.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
       
        public DbSet<EmpModel> employees { get; set; }
    }
}
