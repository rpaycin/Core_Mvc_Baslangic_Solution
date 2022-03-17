using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
    }
}
