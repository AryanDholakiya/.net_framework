using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _01_first_WebApi_Framework.Models
{
    public class First_framework 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Branch { get; set; }
    }
}