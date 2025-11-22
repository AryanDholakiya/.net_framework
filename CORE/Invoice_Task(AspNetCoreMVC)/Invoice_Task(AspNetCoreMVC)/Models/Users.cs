using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice_Task_AspNetCoreMVC_.Models
{
    [Table("UserInfo")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }


        public List<Product> Products { get; set; } = new List<Product>();
    }
}   
