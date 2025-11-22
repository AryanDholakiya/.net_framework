using System.ComponentModel.DataAnnotations;

namespace NEWcrud.Models
{
    public class PetCountries
    {
        [Key]
        public int CountryId { get; set; }
        public string countryName { get; set; }

        //public List<Pet> pets { get; set; }
    }
}
