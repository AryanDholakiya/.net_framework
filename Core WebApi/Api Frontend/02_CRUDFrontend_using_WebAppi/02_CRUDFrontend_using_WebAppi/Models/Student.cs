using System.ComponentModel.DataAnnotations;

namespace _02_CRUDFrontend_using_WebAppi.Models
{
    public class Student
    {
        [Key]
        public int grNumber { get; set; }
        [Required]
        public string sname { get; set; }
        [Required]
        public string sgender { get; set; }
        [Required]
        public int sage { get; set; }
        [Required]
        public int sstd { get; set; }
    }
}
