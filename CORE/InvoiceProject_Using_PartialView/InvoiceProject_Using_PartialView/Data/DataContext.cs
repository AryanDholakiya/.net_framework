using InvoiceProject_Using_PartialView.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProject_Using_PartialView.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Customer> customers{ get; set; }
        public DbSet<Product> products{ get; set; }
    }
}
