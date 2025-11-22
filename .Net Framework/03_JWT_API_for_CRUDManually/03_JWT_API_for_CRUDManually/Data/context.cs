using _03_JWT_API_for_CRUDManually.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_JWT_API_for_CRUDManually.Data
{
    public class context : DbContext
    {
        public context(DbContextOptions<context> options) : base(options)
        {
            
        }

        public DbSet<Login> students { get; set; }
    }
}
