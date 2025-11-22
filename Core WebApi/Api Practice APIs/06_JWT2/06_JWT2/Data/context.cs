using _06_JWT2.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_JWT2.Data
{
    public class context : DbContext 
    {
        public context(DbContextOptions<context> options) : base(options)
        {
            
        }

        public DbSet<LoginModel> users { get; set; }
    }
}
