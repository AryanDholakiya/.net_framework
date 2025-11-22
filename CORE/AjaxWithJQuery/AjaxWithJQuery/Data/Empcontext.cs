using AjaxWithJQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace AjaxWithJQuery.Data
{
    public class Empcontext : DbContext
    {
        public Empcontext(DbContextOptions<Empcontext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}
