using Ai_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Ai_CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
