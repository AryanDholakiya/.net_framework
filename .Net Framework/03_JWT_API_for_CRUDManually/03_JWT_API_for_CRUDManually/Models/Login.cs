using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _03_JWT_API_for_CRUDManually.Models
{
    [Table("StudentAccount")]
    public class Login
    {
        [Key]
        public int SId { get; set; }
        [Required]
        public string? LoginStudentName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
