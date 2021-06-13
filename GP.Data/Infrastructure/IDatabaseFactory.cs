using System;

namespace GP.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        IDatabase Create();
    }
}
