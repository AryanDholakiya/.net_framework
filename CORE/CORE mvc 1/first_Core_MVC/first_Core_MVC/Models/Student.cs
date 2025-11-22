using System.ComponentModel.DataAnnotations;

namespace first_Core_MVC.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        public int Sstd { get; set; }
    }
}
