using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _03_Crud_Manually.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int SId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        [Range(18,25,ErrorMessage="Age must be between 18 to 25")]
        public int Age { get; set; }


        public byte[] Photo { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Branch { get; set; }


    }
}