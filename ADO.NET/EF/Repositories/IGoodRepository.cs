using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.EF.Models;
namespace ADO.NET.EF.Repositories
{
    public interface IGoodRepository
    {
        IEnumerable<Good> GetAll();
        Good GetById(int id);
        void Insert(Good good);
        void Update(Good good);
        void Delete(Good good);
    }
}
