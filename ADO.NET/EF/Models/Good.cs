using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.EF.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal PriceForRetail { get; set; }
        public decimal PriceForWholeSale { get; set; }


        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
    }
}
