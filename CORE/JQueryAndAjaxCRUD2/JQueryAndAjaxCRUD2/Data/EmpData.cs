using JQueryAndAjaxCRUD2.Models;
using Microsoft.EntityFrameworkCore;

namespace JQueryAndAjaxCRUD2.Data
{
    public class EmpData : DbContext
    {
        public EmpData(DbContextOptions<EmpData> options) : base (options)
        {
            
        }

        public DbSet<EmpModel> Employyee {  get; set; }
        public DbSet<ReviewModel> reviewData {  get; set; }
        public DbSet<Email> TotalEmail { get; set; }







        //Note: Ahiya "Employyee" aapyu tya always evu name aapo je tamara table nu name 6 ane je table  mathi data lavvo 6.
        //jo aam nthi krvu to model ma upr "[Table("Employees")]" specify kro.
    }
}
