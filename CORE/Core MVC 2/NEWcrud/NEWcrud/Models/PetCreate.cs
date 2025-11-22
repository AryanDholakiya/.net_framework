using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEWcrud.Models
{
    public class PetCreate
    {
       
        public int petId { get; set; }

        [Required]
        [StringLength(100)]
        public string petName { get; set; }
        public int petAge { get; set; }

        [Required]
        public DateOnly petAdoptedDate { get; set; }

        //[RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be 'Male' or 'Female'.")]  //note this annotation  // here in our view we'll show the radio button for this field so, there is no any complexity of writing complex regular expressions.
        [Required]
        public string petGender { get; set; }

        public string? Hobbies { get; set; }

        public string? petBreed { get; set; }

        public string? PetPhoto { get; set; }

        [NotMapped]
        [Required]
        public IFormFile file { get; set; }


        [ForeignKey("PetCountryId")]
        public PetCountries? petCountries { get; set; }
        public int? PetCountryId { get; set; }
    }
}
