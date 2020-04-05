using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL.Models;
using EFDAL.Repositories;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.ModelsBO;
namespace BusinessLogicLayer.Services
{
    public class EFService:IService
    {
        UnitOfWork UnitOfWork;
        List<GoodBO> goods;
        List<CategoryBO> categories;
        List<SupplierBO> suppliers;

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryBO>();
            cfg.CreateMap<Supplier, SupplierBO>();
            cfg.CreateMap<Good, GoodBO>();
        }).CreateMapper();

        public EFService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;

            goods = mapper.Map<IEnumerable<Good>, List<GoodBO>>(unitOfWork.GoodRepository.GetAll());
            categories = mapper.Map<IEnumerable<Category>, List<CategoryBO>>(unitOfWork.CategoryRepository.GetAll());
            suppliers = mapper.Map<IEnumerable<Supplier>, List<SupplierBO>>(UnitOfWork.SupplierRepository.GetAll());
        }

        public IEnumerable<GoodBO> GetGoodsByCategory(string category)
        {
            return goods
                .Where(c => c.Category.Name.Contains(category));
        }


        public IEnumerable<SupplierBO> GetSupplierByCategory(string category)
        {
            return goods
                .Where(c => c.Category.Name.Contains(category))
                .Select(c => c.Supplier)
                .Distinct()
                .ToList();
        }

        public IEnumerable<GoodBO> GetGoodsBySupplier(string supplierName)
        {
            return goods
                .Where(c => c.Supplier.Name.Contains(supplierName))
                .ToList();
        }

        public IEnumerable<GoodBO> GetGoodsWithSpecifiedPrice(decimal Price)
        {
            return goods
                .Where(c => c.PriceForRetail == Price)
                .ToList();
        }

        public GoodBO GetGoodWithMinPriceByCategory(string category)
        {
            var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

            return result
                .Where(c => c.PriceForRetail == result.Min(d => d.PriceForRetail))
                .First();
        }

        public GoodBO GetGoodWithMaxPriceByCategory(string category)
        {
            var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

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
