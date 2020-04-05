using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.EF.Models;
namespace ADO.NET.EF.Repositories
{
    public class GoodRepository:IGoodRepository
    {
        private ApplicationDbContext _context;
        public GoodRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public void Insert(Good good)
        {
            _context.Goods.Add(good);
        }

        public void Update(Good good)
        {
            _context.Entry(good).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Good good)
        {
            _context.Goods.Remove(good);
        }

        public IEnumerable<Good> GetAll()
        {
            return _context.Goods;
        }

        public Good GetById(int id)
        {
            return _context.Goods.FirstOrDefault(p => p.Id==id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
