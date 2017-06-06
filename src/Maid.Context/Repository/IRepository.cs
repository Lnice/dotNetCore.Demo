using System;
using System.Linq;
using System.Linq.Expressions;

namespace Maid.Context.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        IQueryable<T> Including(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> OrderBy<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderby);
        IQueryable<T> Page<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderby, out int total, int index = 0, int size = 50);
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
