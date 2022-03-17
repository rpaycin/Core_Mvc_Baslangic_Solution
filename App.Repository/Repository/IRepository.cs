using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repository
{
    public interface IRepository <TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();

        Task<IQueryable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
