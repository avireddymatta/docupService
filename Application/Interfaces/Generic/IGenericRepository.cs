using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);


        void Add(T entity);
        void AddRange(IEnumerable<T> entities);


        void Update(T entity);


        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


        IQueryable<T> FindAsQueryable();
        IQueryable<T> FindAsQueryable(Expression<Func<T, bool>> predicate);
    }
}