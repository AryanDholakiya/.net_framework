using Microsoft.EntityFrameworkCore;
using Partial_View_Example.Models;

namespace Partial_View_Example.data
{
    public class DbContextfile: DbContext
    {
        public DbContextfile(DbContextOptions<DbContextfile> options): base(options) 
        {
            
        }

        public DbSet<User> users { get; set; }
    }
}
