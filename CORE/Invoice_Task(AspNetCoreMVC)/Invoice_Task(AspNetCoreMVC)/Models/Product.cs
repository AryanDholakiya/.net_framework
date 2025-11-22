using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice_Task_AspNetCoreMVC_.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int PId { get; set; }
        public string PName { get; set; }
        public int PQuantity { get; set; }
        public int PPrice { get; set; }
        public int Total { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Users? user { get; set; }
    }
}
