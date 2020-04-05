using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.EF.Models;
namespace ADO.NET.EF.Repositories
{
    public interface ISupplierRepository
    {
        void Insert(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Supplier supplier);

        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
    }
}
