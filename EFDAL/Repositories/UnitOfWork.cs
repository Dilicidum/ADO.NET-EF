using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL.Models;
using EFDAL.Repositories;
using EFDAL.Interfaces;
namespace EFDAL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _context;
        private readonly GenericRepository<Category> _categoryRepository;
        private readonly GenericRepository<Good> _goodRepository;
        private readonly GenericRepository<Supplier> _supplierRepository;

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                return _categoryRepository ?? new GenericRepository<Category>(_context);
            }
        }

        public GenericRepository<Good> GoodRepository
        {
            get
            {
                return _goodRepository ?? new GenericRepository<Good>(_context);
            }
        }

        public GenericRepository<Supplier> SupplierRepository
        {
            get
            {
                return SupplierRepository ?? new GenericRepository<Supplier>(_context);
            }
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Non generic Repositories
        //private CategoryRepository _categoryRepository;
        //private GoodRepository _goodRepository;
        //private SupplierRepository _supplierRepository;

        //public CategoryRepository CategoryRepository
        //{
        //    get
        //    {
        //        if (_categoryRepository == null) _categoryRepository = new CategoryRepository(_context);
        //        return _categoryRepository;
        //    }
        //}

        //public SupplierRepository SupplierRepository
        //{
        //    get
        //    {
        //        if (_supplierRepository == null) _supplierRepository = new SupplierRepository(_context);
        //        return _supplierRepository;
        //    }
        //}

        //public GoodRepository GoodRepository
        //{
        //    get
        //    {
        //        if (_goodRepository == null) _goodRepository = new GoodRepository(_context);
        //        return _goodRepository;
        //    }
        //}
    }
}
