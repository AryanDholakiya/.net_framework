using LoginFormWithSession.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginFormWithSession.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            
        }
        public DbSet<User> users { get; set; }
    }
}
