using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using EFDAL.Models;
namespace EFDAL.Configures
{
    class GoodConfiguration : EntityTypeConfiguration<Good>
    {
       public GoodConfiguration()
        {
            this.ToTable("Goods")
            .HasKey<int>(g => g.Id);

            this.HasRequired(g => g.Supplier)
                .WithMany(s => s.Goods)
                .HasForeignKey<int>(c => c.SupplierId);

            
            this.HasRequired(s => s.Category)
                .WithMany(s => s.Goods)
                .HasForeignKey<int>(b => b.CategoryId);
        }
    }
}
