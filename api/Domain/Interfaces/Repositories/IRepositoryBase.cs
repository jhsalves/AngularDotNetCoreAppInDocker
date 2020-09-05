using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes);
    }
}
