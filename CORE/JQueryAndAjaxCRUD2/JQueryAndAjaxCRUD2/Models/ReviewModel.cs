using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JQueryAndAjaxCRUD2.Models
{
    [Table("reviewTable")]
    public class ReviewModel
    {
        [Key]
        public int RId { get; set; }
        public string Title { get; set; }  
        public string Review { get; set; }
    }
}
