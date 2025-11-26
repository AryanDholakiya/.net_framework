using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _02_CrudApi_framework.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext() : base("MyConnectionString")
        {
            
        }

        public DbSet<StudentsModel> students { get; set; }
    }
}