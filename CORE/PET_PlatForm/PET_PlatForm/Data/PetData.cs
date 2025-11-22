using Microsoft.EntityFrameworkCore;
using PET_PlatForm.Models;

namespace PET_PlatForm.Data
{
    public class PetData : DbContext
    {
        public PetData(DbContextOptions<PetData> options) : base(options) 
        {
            
        }

        public DbSet<availablePets> AvailablePets { get; set; } 
    }
}
