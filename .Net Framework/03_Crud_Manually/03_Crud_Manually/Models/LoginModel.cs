using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _03_Crud_Manually.Models
{
    [Table("StudentAccount")]
    public class LoginModel
    {
        [Key]
        public int SId { get; set; }

        [Display(Name = "User Name:")]
        public string LoginStudentName { get; set; }

        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}