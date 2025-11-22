using System.ComponentModel.DataAnnotations;

namespace _2_Employee_Crud_using_Database.Models
{
    public class EmpModel
    {
        [Key]
        public int empId { get; set; }

        public string empName { get; set; }

        public string empEmail { get; set; }

        public int EmpSalary { get; set; }
    }
}
