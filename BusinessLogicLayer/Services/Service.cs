using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL.Models;
using EFDAL.Repositories;
using EFDAL.Interfaces;
using ADO.NET.ADO;
using ADO.NET.Models;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.ModelsBO;
namespace BusinessLogicLayer.Services
{
    public class Service:IService
    {
        EFDAL.Interfaces.IUnitOfWork EFUnitOfWork;
        ADO.NET.ADO.IUnitOfWork ADOUnitOfWork;
            
        List<GoodBO> goods;
        List<CategoryBO> categories;
        List<SupplierBO> suppliers;

        IMapper EFmapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EFDAL.Models.Category, CategoryBO>();
            cfg.CreateMap<EFDAL.Models.Supplier, SupplierBO>();
            cfg.CreateMap<EFDAL.Models.Good, GoodBO>();
        }).CreateMapper();

        IMapper ADOMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ADO.NET.Models.CategoryOfGoods, CategoryBO>();
            cfg.CreateMap<ADO.NET.Models.Supplier, SupplierBO>();
            cfg.CreateMap<ADO.NET.Models.Good, GoodBO>();
        }).CreateMapper();

        public Service(EFDAL.Interfaces.IUnitOfWork unitOfWork)
        {
            EFUnitOfWork = unitOfWork;

            goods = EFmapper.Map<IEnumerable<EFDAL.Models.Good>, List<GoodBO>>(unitOfWork.GoodRepository.GetAll());
            categories = EFmapper.Map<IEnumerable<EFDAL.Models.Category>, List<CategoryBO>>(unitOfWork.CategoryRepository.GetAll());
            suppliers = EFmapper.Map<IEnumerable<EFDAL.Models.Supplier>, List<SupplierBO>>(EFUnitOfWork.SupplierRepository.GetAll());
        }

        public Service(ADO.NET.ADO.IUnitOfWork unitOfWork)
        {
            ADOUnitOfWork = unitOfWork;
            goods = ADOMapper.Map<IEnumerable<ADO.NET.Models.Good>, List<GoodBO>>(ADOUnitOfWork.Products.GetAll());
            suppliers = ADOMapper.Map<IEnumerable<ADO.NET.Models.Supplier>, List<SupplierBO>>(ADOUnitOfWork.Suppliers.GetAll());
            categories = ADOMapper.Map<IEnumerable<CategoryOfGoods>, List<CategoryBO>>(ADOUnitOfWork.Categories.GetAll());
        }

        public IEnumerable<GoodBO> EFGetGoodsByCategory(string category)
        {
            return goods
                .Where(c => c.Category.Name.Contains(category));
        }


        public IEnumerable<SupplierBO> EFGetSupplierByCategory(string category)
        {
            return goods
                .Where(c => c.Category.Name.Contains(category))
                .Select(c => c.Supplier)
                .Distinct()
                .ToList();
        }

        public IEnumerable<GoodBO> EFGetGoodsBySupplier(string supplierName)
        {
            return goods
                .Where(c => c.Supplier.Name.Contains(supplierName))
                .ToList();
        }

        public IEnumerable<GoodBO> EFGetGoodsWithSpecifiedPrice(decimal Price)
        {
            return goods
                .Where(c => c.PriceForRetail == Price)
                .ToList();
        }

        public GoodBO EFGetGoodWithMinPriceByCategory(string category)
        {
            var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

            return result
                .Where(c => c.PriceForRetail == result.Min(d => d.PriceForRetail))
                .First();
        }

        public GoodBO EFGetGoodWithMaxPriceByCategory(string category)
        {
            var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

            return result
                .Where(c => c.PriceForRetail == result.Max(d => d.PriceForRetail))
                .First();
        }

        public IEnumerable<GoodBO> ADOGetGoodsByCategory(string category)
        {
            return goods
                .Where(c => c.Category.Name.Contains(category));
        }

        public IEnumerable<SupplierBO> ADOGetSupplierByCategory(string category)
        {
            return goods
                .Where(c => c.Category.Name.Contains(category))
                .Select(c => c.Supplier)
                .Distinct()
                .ToList();
        }

        public IEnumerable<GoodBO> ADOGetGoodsBySupplier(string supplierName)
        {
            return goods
                .Where(c => c.Supplier.Name.Contains(supplierName))
                .ToList();
        }

        public IEnumerable<GoodBO> ADOGetGoodsWithSpecifiedPrice(decimal Price)
        {
            return goods
                .Where(c => c.PriceForRetail == Price)
                .ToList();
        }

        public GoodBO ADOGetGoodWithMinPriceByCategory(string category)
        {
            var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

            return result
                .Where(c => c.PriceForRetail == result.Min(d => d.PriceForRetail))
                .First();
        }

        public GoodBO ADOGetGoodWithMaxPriceByCategory(string category)
        {
            var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

            return result
                .Where(c => c.PriceForRetail == result.Max(d => d.PriceForRetail))
                .First();
        }

        public void Dispose()
        {
            EFUnitOfWork.Dispose();
        }


    }
}
