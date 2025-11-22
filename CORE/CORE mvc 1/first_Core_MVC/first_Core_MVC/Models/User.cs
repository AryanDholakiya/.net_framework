using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace first_Core_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
