using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace file_upload_CoreMVC.Models
{
    [Table("Person")] //this is not neccessary to give the table name here but if any error will occur then it will be useful .
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        public byte[]? personImg { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "The Person Image file is required.")]
        public IFormFile PersonImgFile { get; set; }
    }
}
