using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JQueryAndAjaxCRUD2.Models
{
    [Table("EmailTable")]
    public class Email
    {
        [Key]
        public int EId {  get; set; }
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime? SentDate { get; set; }

        [NotMapped]
        public List<IFormFile>? Attachment { get; set; }
    }
}
