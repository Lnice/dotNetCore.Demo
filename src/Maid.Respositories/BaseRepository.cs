﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Maid.Context.Repository;
using Maid.Context;

namespace Maid.Respositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _context = context;
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> Including(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate);
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderby)
        {
            IQueryable<T> query = _context.Set<T>();
            var resetSet = predicate != null ? query.Where(predicate) : query;
            resetSet = orderby != null ? resetSet.OrderBy(orderby) : resetSet;
            return resetSet;
        }

        public IQueryable<T> Page<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderby, out int total, int index = 0, int size = 50)
        {
            IQueryable<T> query = _context.Set<T>();
            var resetSet = predicate != null ? query.Where(predicate) : query;
            total = resetSet.Count();
            resetSet = orderby != null ? resetSet.OrderBy(orderby) : resetSet;
            var skipCount = index * size;
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            return resetSet;
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Single(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            var dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Update(T entity)
        {
            var dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
