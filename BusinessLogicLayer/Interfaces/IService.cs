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
        IEnumerable<GoodBO> EFGetGoodsByCategory(string category);
        IEnumerable<SupplierBO> EFGetSupplierByCategory(string category);
        IEnumerable<GoodBO> EFGetGoodsBySupplier(string supplierName);
        IEnumerable<GoodBO> EFGetGoodsWithSpecifiedPrice(decimal Price);
        GoodBO EFGetGoodWithMinPriceByCategory(string category);
        GoodBO EFGetGoodWithMaxPriceByCategory(string category);
        void Dispose();
    }
}