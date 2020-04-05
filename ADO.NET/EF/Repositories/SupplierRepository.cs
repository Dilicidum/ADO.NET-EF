using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.EF.Models;
namespace ADO.NET.EF.Repositories
{
    public class SupplierRepository:ISupplierRepository
    {
        private ApplicationDbContext _context;
        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Insert(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }

        public void Update(Supplier supplier)
        {
            _context.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers;
        }

        public Supplier GetById(int id)
        {
            return _context.Suppliers.FirstOrDefault(c => c.Id == id);
        }
    }
}