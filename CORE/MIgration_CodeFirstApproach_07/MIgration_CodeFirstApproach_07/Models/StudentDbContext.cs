using Microsoft.EntityFrameworkCore;

namespace MIgration_CodeFirstApproach_07.Models
{
    public class StudentDbContext : DbContext 
    {
        public StudentDbContext(DbContextOptions options): base(options) //base keyword is used for "call the constructor" of parent class(DbContext)
        {
            
        }

        public DbSet<Student> students { get; set; } // Dbset database na table ne represent krva bnavay 6. datbase table bnse tenu name pn "students" j hse.
    }
}
