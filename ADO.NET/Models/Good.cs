using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal PriceRetail { get; set; }
        public decimal PriceWholeSale { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public void Show()
        {
            Console.WriteLine($"{Id}\t {Name}" +
                $"{Amount}\t {PriceRetail}\t {PriceWholeSale}\t {SupplierId}\t {CategoryId}\t");
        }
    }
}
