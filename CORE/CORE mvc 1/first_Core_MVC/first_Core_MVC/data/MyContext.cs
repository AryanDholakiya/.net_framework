using first_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace first_Core_MVC.data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

      public DbSet<Student> students { get; set; }
    }
}
