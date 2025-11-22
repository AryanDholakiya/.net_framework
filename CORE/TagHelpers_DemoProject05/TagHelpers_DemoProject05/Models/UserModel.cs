using System.ComponentModel.DataAnnotations;


namespace TagHelpers_DemoProject05.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name Required!")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name= "Email Address")]
        [EmailAddress(ErrorMessage ="Invalid Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Age not Valid.")]
        [Range(18,100,ErrorMessage ="Must be in 18 to 100")]
        [Display(Name ="Age")]
        public int? Age { get; set; }

        public byte[] Photo { get; set; }
    }
}


//NOTE: real time error messages show to j thy jo "_ValidationScriptsPartial.cshtml" hoi je mvc file bnavie tyare in-built aave