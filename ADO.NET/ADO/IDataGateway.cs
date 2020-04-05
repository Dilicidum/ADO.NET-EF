using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ADO
{
    interface IDataGateway<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
