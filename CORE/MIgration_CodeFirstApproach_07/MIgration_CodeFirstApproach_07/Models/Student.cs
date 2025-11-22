using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIgration_CodeFirstApproach_07.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }

        [Column("StudentName", TypeName = "varchar(100)")]
        public string SName { get; set; }

        [Column("StudentGender", TypeName = "varchar(20)")]
        public String Gender { get; set; }
        public int Age { get; set; }

        public int Std { get; set; }
    }
}
