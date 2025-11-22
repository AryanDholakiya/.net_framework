using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceProject_Using_PartialView.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }


        public List<Product> Products { get; set; } = new List<Product>();
        //this line means that one customer can many product so we can access that products directly from the customer. we'll store all product of particular customer here.
        //new List<Product>(); -> means that if there is no any product customer then it will not throw the nullexception and return null list.
    }
}
