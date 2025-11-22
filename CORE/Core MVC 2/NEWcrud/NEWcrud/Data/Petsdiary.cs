using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NEWcrud.Models;

namespace NEWcrud.Data
{
    public class Petsdiary : DbContext
    {
        public Petsdiary(DbContextOptions<Petsdiary> options) : base(options)
        { 
        }

        public DbSet<Pet> pets {  get; set; } //"Pet" => This must be same as our Model's Class name.

        public DbSet<PetCountries> PetCountries { get; set; }
    }
}
