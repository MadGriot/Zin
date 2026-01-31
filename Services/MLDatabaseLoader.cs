using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Zin.Utils;

namespace Zin.Services
{
    public class MLDatabaseLoader<TContext, TData>(IDbContextFactory<TContext> dbContextFactory, MLContext mLContext)
        where TContext : DbContext
        where TData : class, new()
    {
        private readonly IDbContextFactory<TContext> dbContextFactory = dbContextFactory;
        private readonly MLContext mLContext = mLContext;

        public IDataView Load(string sqlQuery)
        {
            using TContext database = dbContextFactory.CreateDbContext();
            DatabaseInfo databaseInfo = database.GetDatabaseInfo();

            DatabaseLoader loader = mLContext.Data.CreateDatabaseLoader<TData>();
            DatabaseSource dbSource = new DatabaseSource(databaseInfo.DbProvider, databaseInfo.ConnectionString, sqlQuery);

            return loader.Load(dbSource);
        }

    }
}
