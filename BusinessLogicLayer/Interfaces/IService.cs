using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.ModelsBO;


namespace BusinessLogicLayer.Interfaces
{
    public interface IService
    {
        IEnumerable<GoodBO> GetGoodsByCategory(string category);
        IEnumerable<SupplierBO> GetSupplierByCategory(string category);
        IEnumerable<GoodBO> GetGoodsBySupplier(string supplierName);
        IEnumerable<GoodBO> GetGoodsWithSpecifiedPrice(decimal Price);
        GoodBO GetGoodWithMinPriceByCategory(string category);
        GoodBO GetGoodWithMaxPriceByCategory(string category);
        void Dispose();
    }
}