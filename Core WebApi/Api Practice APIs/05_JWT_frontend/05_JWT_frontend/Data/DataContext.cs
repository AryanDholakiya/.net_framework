using Microsoft.EntityFrameworkCore;

namespace _05_JWT_frontend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        DbSet<DataContext> users {  get; set; }
    }
}
