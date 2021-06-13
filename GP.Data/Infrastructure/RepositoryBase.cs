using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GP.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        IDatabase dataBase;
        DbSet<T> dbSet;
        public RepositoryBase(IDatabase dataBase)
        {
            this.dataBase = dataBase;
            this.dbSet = dataBase.GetDbSet<T>();
        }
        public virtual T GetById(long id)
        {
            return dbSet.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataBase.MarkAsChanged(entity);
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            foreach (T entity in dbSet.Where<T>(where))
            {
                Delete(entity);
            }
        }
    }
}
