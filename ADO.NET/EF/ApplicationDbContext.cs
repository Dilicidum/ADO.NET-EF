using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.EF.Models;
using System.Data.Entity;

namespace ADO.NET.EF
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Good> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Category")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Good>()
                .ToTable("Goods")
                .HasKey(g => g.Id);

            modelBuilder.Entity<Supplier>()
                .ToTable("Supplier")
                .HasKey(s => s.Id);

            modelBuilder.Entity<Good>()
                .HasRequired(g => g.Supplier)
                .WithMany(s => s.Goods)
                .HasForeignKey<int>(c=>c.SupplierId);

            modelBuilder.Entity<Good>()
                .HasRequired(s => s.Category)
                .WithMany(s => s.Goods)
                .HasForeignKey<int>(b=>b.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
