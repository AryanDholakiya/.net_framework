using System.ComponentModel.DataAnnotations;

namespace Ai_CRUD.Models
{
    public class Person 
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1,100)]  // NOTE Validator
        public int? Age { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be in Digits and should be exactly 10 digits.")]
        public string MobileNumber { get; set; }

        public byte[]? Photo { get; set; } //store image in binary format
    }
}
