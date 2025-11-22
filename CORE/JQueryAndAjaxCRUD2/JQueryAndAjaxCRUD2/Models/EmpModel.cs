using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JQueryAndAjaxCRUD2.Models
{
    [Table("Employees")]
    public class EmpModel
    {
        [Key]
        public int empId{get; set; }
        public string empName{get; set; }
        public string empEmail{get; set; }
        public int EmpSalary{get; set; }
        public byte[]? empPhoto{get; set; }

        [NotMapped]
        public string? photoForEdit { get; set; }
        //aa umervani jroor etle padi because the jyare edit upr click thy tyare already je photo 6 te show thvo joie.
        //Razor can’t directly display a byte[]. -->So you should prepare a Base64 string in your controller.
    }
}
