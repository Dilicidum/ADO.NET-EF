using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ADO
{
    public interface IUnitOfWork:IDisposable
    {
        GoodsDAL Products { get; }
        DbCategoryDAL Categories { get; }
        SupplierDAL Suppliers { get; }
        void Dispose();

    }
}
