using System.ComponentModel.DataAnnotations;

namespace LoginFormWithSession.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(18,35)]
        public int? Age { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "❌Enter the Valid Email Adderess.")]
        public string Email { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[\W_]).{6,}$", ErrorMessage = "Password must be at least 6 characters long.<br/>contain at least one symbol.<br/>contain at least one number.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
