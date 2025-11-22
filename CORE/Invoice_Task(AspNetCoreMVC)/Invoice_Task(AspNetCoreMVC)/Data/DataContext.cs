using Invoice_Task_AspNetCoreMVC_.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Task_AspNetCoreMVC_.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.PId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.user)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.CustomerId)  // tell EF foreign key column name
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
