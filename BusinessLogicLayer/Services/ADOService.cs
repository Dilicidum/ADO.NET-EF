using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using ADO.NET.ADO;
using ADO.NET.Models;
using BusinessLogicLayer.ModelsBO;
using System.Data.Sql;
using System.Data.SqlClient;
namespace BusinessLogicLayer.Services
{
    public class ADOService:IService
    {
        ADOUnitOfWork UnitOfWork;

        List<CategoryBO> Categories;
        List<SupplierBO> Suppliers;
        List<GoodBO> Goods;

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CategoryOfGoods, CategoryBO>();
            cfg.CreateMap<Supplier, SupplierBO>();
            cfg.CreateMap<Good, GoodBO>();
        }).CreateMapper();

        public ADOService(ADOUnitOfWork work)
        {
            UnitOfWork = work;

            Goods = mapper.Map<IEnumerable<Good>, List<GoodBO>>(UnitOfWork.Products.GetAll());
            Suppliers = mapper.Map<IEnumerable<Supplier>, List<SupplierBO>>(UnitOfWork.Suppliers.GetAll());
            Categories = mapper.Map<IEnumerable<CategoryOfGoods>, List<CategoryBO>>(UnitOfWork.Categories.GetAll());
        }

        public IEnumerable<GoodBO> GetGoodsByCategory(string category)
        {
            return Goods
                .Where(c => c.Category.Name.Contains(category));
        }

        public IEnumerable<SupplierBO> GetSupplierByCategory(string category)
        {
            return Goods
                .Where(c => c.Category.Name.Contains(category))
                .Select(c => c.Supplier)
                .Distinct()
                .ToList();
        }

        public IEnumerable<GoodBO> GetGoodsBySupplier(string supplierName)
        {
            return Goods
                .Where(c => c.Supplier.Name.Contains(supplierName))
                .ToList();
        }

        public IEnumerable<GoodBO> GetGoodsWithSpecifiedPrice(decimal Price)
        {
            return Goods
                .Where(c => c.PriceForRetail == Price)
                .ToList();
        }

        public GoodBO GetGoodWithMinPriceByCategory(string category)
        {
            var result = Goods.Where(c => c.Category.Name.Contains(category)).ToList();

            return result
                .Where(c => c.PriceForRetail == result.Min(d => d.PriceForRetail))
                .First();
        }

        public GoodBO GetGoodWithMaxPriceByCategory(string category)
        {
            var result = Goods.Where(c => c.Category.Name.Contains(category)).ToList();

            return result
                .Where(c => c.PriceForRetail == result.Max(d => d.PriceForRetail))
                .First();
        }

        public void Dispose()
        {
            
            UnitOfWork.Dispose();
        }

    }
}
