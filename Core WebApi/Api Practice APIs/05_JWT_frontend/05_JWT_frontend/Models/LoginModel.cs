using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_JWT_frontend.Models
{
    [Table("Users")]
    public class LoginModel
    {
        [Key]
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
