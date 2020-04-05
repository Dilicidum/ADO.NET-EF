using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.EF.Repositories
{
    public interface IGenericRepository<TEntity>where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);

    }
}
