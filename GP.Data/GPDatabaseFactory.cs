using GP.Data.Infrastructure;

namespace GP.Data
{
    public class GPDatabaseFactory : IDatabaseFactory
    {
        public IDatabase Create()
        {
            return new GPDatabase();
        }
    }
}
