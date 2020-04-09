using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL.Models;
using System.Data.Entity;
using EFDAL.Configures;
namespace EFDAL
{
    public class ApplicationDbContext : DbContext//context
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Good> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new CategoryEntityConfiguration());
            modelBuilder.Configurations.Add(new GoodConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
