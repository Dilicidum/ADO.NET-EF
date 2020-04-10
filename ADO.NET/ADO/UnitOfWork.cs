using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Models;
namespace ADO.NET.ADO
{
    public class ADOUnitOfWork:IUnitOfWork
    {
        private GoodsDAL goodRepository;
        private SupplierDAL supplierRepository;
        private DbCategoryDAL categoryRepository;

        public ADOUnitOfWork()
        {
        }

        public GoodsDAL Products
        {
            get
            {
                if (goodRepository == null)
                {
                    goodRepository = new GoodsDAL();
                }

                return goodRepository;
            }
        }

        public DbCategoryDAL Categories
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new DbCategoryDAL();
                }

                return categoryRepository;
            }
        }

        public SupplierDAL Suppliers
        {
            get
            {
                if (supplierRepository == null)
                {
                    supplierRepository = new SupplierDAL();
                }

                return supplierRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
