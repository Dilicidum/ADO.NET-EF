using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL.Models;
using System.Data.Entity.ModelConfiguration;
namespace EFDAL.Configures
{
    class SupplierConfiguration:EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            this.ToTable("Supplier")
                .HasKey<int>(s => s.Id);
        }
    }
}
