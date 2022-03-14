using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual void Add(T entity)
        {
            dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }


        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }



        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }


        public IQueryable<T> FindAsQueryable() => context.Set<T>().AsQueryable<T>();

        public IQueryable<T> FindAsQueryable(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).AsQueryable();
        }

    }
}