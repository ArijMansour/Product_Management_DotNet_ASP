using GP.Data.Infrastructure;
using System.Data.Entity;

namespace GP.Data
{
    public class GPDatabase : Disposable, IDatabase
    {
        GPContext context = new GPContext();
        protected override void DisposeCore()
        {
            base.DisposeCore();
            context?.Dispose();
        }
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return context.Set<T>();
        }
        public void MarkAsChanged<T>(T entity) where T : class
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
