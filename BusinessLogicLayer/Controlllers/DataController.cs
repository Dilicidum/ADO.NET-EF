using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.EF.Models;
using BusinessLogicLayer.Controlllers;
using EFDAL.Models;
using EFDAL.Repositories;
using System.Data.Entity;
namespace BusinessLogicLayer.Controlllers
{

    public class DataController
    {
        //private UnitOfWork _unitOfWork;
        //public DataController( UnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //public List<EFDAL.Models.Good> GetGoodsByCategory(string category)
        //{
        //    var goods = _unitOfWork.GoodRepository.GetAll().ToList();
        //    return goods
        //        .Where(c => c.Category.Name.Contains(category))
        //        .ToList();
        //}

        //public List<EF.Models.Supplier> GetSupplierByCategory(string category)
        //{
        //    var goods = _unitOfWork.GoodRepository.GetAll().ToList();
        //    return goods
        //        .Where(c => c.Category.Name.Contains(category))
        //        .Select(c => c.Supplier)
        //        .Distinct()
        //        .ToList();
        //}

        //public List<EF.Models.Good> GetGoodsBySupplier(string supplierName)
        //{
        //    var goods = _unitOfWork.GoodRepository.GetAll().ToList();
        //    return goods
        //        .Where(c => c.Supplier.Name.Contains(supplierName))
        //        .ToList();
        //}

        //public List<EF.Models.Good> GetGoodsWithSpecifiedPrice(decimal Price)
        //{
        //    var goods = _unitOfWork.GoodRepository.GetAll().ToList();
        //    return goods
        //        .Where(c => c.PriceForRetail == Price)
        //        .ToList();
        //}

        //public EF.Models.Good GetGoodWithMinPriceByCategory(string category)
        //{
        //    var goods = _unitOfWork.GoodRepository.GetAll().ToList();
        //    var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

        //    return result
        //        .Where(c => c.PriceForRetail == result.Min(d => d.PriceForRetail))
        //        .First();
        //}

        //public EF.Models.Good GetGoodWithMaxPriceByCategory(string category)
        //{
        //    var goods = _unitOfWork.GoodRepository.GetAll().ToList();
        //    var result = goods.Where(c => c.Category.Name.Contains(category)).ToList();

        //    return result
        //        .Where(c => c.PriceForRetail == result.Max(d => d.PriceForRetail))
        //        .First();
        //}
    }
}