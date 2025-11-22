using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceProject_Using_PartialView.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int ProdctId { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        [RegularExpression(@"^\d*\.?\d+$", ErrorMessage = "Enter valid number")]
        public decimal ProductPrice { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }

        public int? CustomerId { get; set; } // int? -> Means product may or may not belong to a Customer 

        [ForeignKey("CustomerId")] 
        public Customer customer { get; set; }

        //If Product.CustomerId = 3 → Product belongs to Customer whose CustomerId = 3.

    }
}
