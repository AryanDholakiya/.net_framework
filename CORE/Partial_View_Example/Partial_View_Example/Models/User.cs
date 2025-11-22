using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Partial_View_Example.Models
{
    [Table("Students")]
    public class User
    {
        [Key]
        public int SId { get; set; }
        [Required]
        public string SName { get; set; }
        [Required]
        public string SAddress { get; set; }
        [Required]
        public int? Sstd { get; set; }
    }
}
