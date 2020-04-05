using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFDAL.Models;
using System.Data.Entity.ModelConfiguration;
namespace EFDAL.Configures
{
    public class CategoryEntityConfiguration:EntityTypeConfiguration<Category>
    {
        public CategoryEntityConfiguration()
        {
            this.ToTable("Category")
               .HasKey<int>(c => c.Id);

            this.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(30)
                .IsOptional();

        }
    }
}
