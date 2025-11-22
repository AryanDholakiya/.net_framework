using System.ComponentModel.DataAnnotations;

namespace Form_Programentor.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Name Field is Required!")]
        [StringLength(20,MinimumLength = 3)] // [MaxLength(3)] could also work same but it can't contains ",MinimumLength"
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only alphabets are allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender field is Required!")]
        public string Gender { get; set; }

        [Required]
        [Range(18,35)]
        public int Age { get; set; }

        [Required]
        public designation Designation { get; set; } // here left sided "designation" is datatype enum and "Designation" is property. 
        //? is for showing an error bcz enum set the first value automatically in field if we don't select any value from dropdown

        public int Salary { get; set; }

        [Required]
        //[EmailAddress]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "❌Enter the Valid Email Adderess.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[\W_]).{6,}$", ErrorMessage = "Password must be at least 6 characters long.<br/>contain at least one symbol.<br/>contain at least one number.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Password doesn't match! check again.")]
        public string ConfirmPassword { get; set; }
    }


    //creating Enum for DropDownList in index.cshtml
    public enum designation
    {
        React_Developer, Angular_Developer, DotNet_Developer, FullStack_Developer
    }
}
