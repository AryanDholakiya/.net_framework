using crud2Migration.Models;
using Microsoft.EntityFrameworkCore;

namespace crud2Migration.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
    }
}
