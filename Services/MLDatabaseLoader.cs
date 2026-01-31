using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Zin.Services.Interfaces;
using Zin.Utils;

namespace Zin.Services
{
    public class MLDatabaseLoader<TContext>(IContextFactory<TContext> dbContextFactory, MLContext mLContext)
        where TContext : DbContext
    {
        private readonly IContextFactory<TContext> dbContextFactory = dbContextFactory;
        private readonly MLContext mLContext = mLContext;

        public IDataView Load<TData>(string sqlQuery) where TData : class
        {
            if (string.IsNullOrWhiteSpace(sqlQuery))
                throw new ArgumentException("SQL query cannot be null or empty.", nameof(sqlQuery));

            using TContext database = dbContextFactory.CreateDbContext();
            DatabaseInfo databaseInfo = database.GetDatabaseInfo();

            DatabaseLoader loader = mLContext.Data.CreateDatabaseLoader<TData>();
            DatabaseSource dbSource = new DatabaseSource(databaseInfo.DbProvider, databaseInfo.ConnectionString, sqlQuery);

            return loader.Load(dbSource);
        }

    }
}
