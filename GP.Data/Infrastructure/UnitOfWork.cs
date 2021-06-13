namespace GP.Data.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        IDatabase dataBase;
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.dataBase = databaseFactory.Create();
        }
        protected override void DisposeCore()
        {
            base.DisposeCore();
            dataBase?.Dispose();
        }
        public void Commit()
        {
            dataBase.SaveChanges();
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(dataBase);
        }
    }
}
