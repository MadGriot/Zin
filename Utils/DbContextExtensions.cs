using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Zin.Utils
{
    public static class DbContextExtensions 
    {
        public static DatabaseInfo GetDatabaseInfo(this DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            DbConnection connection = context.Database.GetDbConnection();

            if (string.IsNullOrWhiteSpace(connection.ConnectionString))
                throw new InvalidOperationException("Connection string is null or empty.");

            DbProviderFactory provider = DbProviderFactories.GetFactory(connection)
                           ?? throw new InvalidOperationException("Could not resolve a provider factory for this connection.");

            return new DatabaseInfo(connection.ConnectionString, provider);
        }
    }
}
