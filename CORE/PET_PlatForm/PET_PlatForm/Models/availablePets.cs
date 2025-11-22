using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PET_PlatForm.Models
{
    [Table("available_pets")] // helpful when error occur: SqlException: Invalid object name 'AvailablePets'.
    public class availablePets
    {
        [Key]
        public int pet_Id { get; set; }

        [Required]
        [MinLength(2)]
        public string pet_name { get; set; }

        [Required]
        [Range(1,20)]
        public int pet_age { get; set; }

        [Required]
        public string pet_breed { get; set; }
        [Required]
        public string pet_gender { get; set; }

        [Required]
        public string pet_city { get; set; }

        [Required]
        public bool vaccinated { get; set; }

        [Required]
        public byte[] pet_photo { get; set; }
    }
}
