using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL.Models;
using EFDAL.Repositories;

namespace EFDAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        GenericRepository<Category> CategoryRepository { get; }
        GenericRepository<Good> GoodRepository { get; }
        GenericRepository<Supplier> SupplierRepository { get; }
        void Save();
        void Dispose();
    }
}
