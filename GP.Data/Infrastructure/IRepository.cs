using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GP.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T GetById(long Id);
        T GetById(string Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
    }
}
