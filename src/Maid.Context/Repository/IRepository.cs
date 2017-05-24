using System;
using System.Linq;
using System.Linq.Expressions;

namespace Maid.Context.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);
        IQueryable<T> Including(params Expression<Func<T, object>>[] includeProperties);
        int Count();
        T Single(Expression<Func<T, bool>> expression);
        T Single(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        bool Exist(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Commit();
    }
}
