using Scheduling.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         string includeProperties = "");
        Task<TEntity> GetById(object id);
        void Add(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity);
    }
}
