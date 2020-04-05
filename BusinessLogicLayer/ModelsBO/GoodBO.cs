using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ModelsBO
{
    public class GoodBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal PriceForRetail { get; set; }
        public decimal PriceForWholeSale { get; set; }

        public virtual CategoryBO Category { get; set; }
        public int CategoryId { get; set; }
        public virtual SupplierBO Supplier { get; set; }
        public int SupplierId { get; set; }
    }
}
