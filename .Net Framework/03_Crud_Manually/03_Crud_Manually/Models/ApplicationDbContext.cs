using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _03_Crud_Manually.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(): base("MyConnectionString")
        {
            
        }

        public DbSet<Student> students{ get; set; }

        public System.Data.Entity.DbSet<_03_Crud_Manually.Models.LoginModel> LoginModels { get; set; }
    }
}