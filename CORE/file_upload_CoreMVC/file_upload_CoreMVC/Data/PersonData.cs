using file_upload_CoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace file_upload_CoreMVC.Data
{
    public class PersonData : DbContext
    {
        public PersonData(DbContextOptions<PersonData> options) : base(options)
        {
        }
        public DbSet<Person> person { get; set; }

    }
}
