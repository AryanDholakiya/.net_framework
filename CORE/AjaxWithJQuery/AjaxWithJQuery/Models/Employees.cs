using System.ComponentModel.DataAnnotations;

namespace AjaxWithJQuery.Models
{
    public class Employees
    {
        [Key]
        public int EmpId { get; set; }       
        public string? EmpName { get; set; }
        public string? EmpEmail { get; set; }
        public int? EmpSalary { get; set; }
    }
}
