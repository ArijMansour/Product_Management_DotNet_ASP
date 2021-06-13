using GP.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GP.Service.Infrastructure
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            UnitOfWork.GetRepository<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            UnitOfWork.GetRepository<T>().Delete(entity);
        }
        public void Delete(Expression<Func<T, bool>> where)
        {
            UnitOfWork.GetRepository<T>().Delete(where);
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return UnitOfWork.GetRepository<T>().Get(where);
        }
        public IEnumerable<T> GetAll()
        {
            return UnitOfWork.GetRepository<T>().GetAll();
        }
        public T GetById(long Id)
        {
            return UnitOfWork.GetRepository<T>().GetById(Id);
        }
        public T GetById(string Id)
        {
            return UnitOfWork.GetRepository<T>().GetById(Id);
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return UnitOfWork.GetRepository<T>().GetMany(where);
        }
        public void Update(T entity)
        {
            UnitOfWork.GetRepository<T>().Update(entity);
        }
    }
}
