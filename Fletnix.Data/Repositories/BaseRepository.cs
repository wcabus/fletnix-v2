using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fletnix.Repositories;

namespace Fletnix.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly FletnixDbContext _context;

        public BaseRepository(FletnixDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> whereExpression)
        {
            return _context.Set<T>().Where(whereExpression);
        }

        public IQueryable<TSelect> Get<TSelect>(Expression<Func<T, TSelect>> selectExpression)
        {
            return _context.Set<T>().Select(selectExpression);
        }

        public IQueryable<TSelect> Get<TSelect>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TSelect>> selectExpression)
        {
            return _context.Set<T>().Where(whereExpression).Select(selectExpression);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereExpression)
        {
            return _context.Set<T>().FirstOrDefaultAsync(whereExpression);
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public T Remove(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }

            return _context.Set<T>().Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}