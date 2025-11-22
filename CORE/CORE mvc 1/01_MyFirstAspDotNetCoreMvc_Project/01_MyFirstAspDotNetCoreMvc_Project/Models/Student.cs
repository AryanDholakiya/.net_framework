using System.ComponentModel.DataAnnotations;

namespace _01_MyFirstAspDotNetCoreMvc_Project.Models
{
    public class Student
    {
        public int StudentRollNo { get; set; }
        [MaxLength(100)]
        public String StudentName { get; set; }
        public string StudentEmail { get; set; }
    }
}
