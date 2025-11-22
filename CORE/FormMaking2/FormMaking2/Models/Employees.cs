using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FormMaking2.Models
{
    public class Employees
    {
        [Required(ErrorMessage = "Empolyee Id is Required")]
        [Range(1,1000,ErrorMessage = "Employee Id not Found.")]
        public int? EmpId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3, ErrorMessage = "name must contains minimum 3 letters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "designation is Required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Contact Number is Required")]
        [StringLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be in Digits and should be exactly 10 digits.")]
        public string ContactNumber { get; set; }
    }
}
