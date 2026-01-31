using Microsoft.EntityFrameworkCore;

namespace Zin.Services
{
    public class DbContextFactory<T>(DbContextOptions<T> options) : IDbContextFactory<T> where T : DbContext
    {
        private readonly DbContextOptions<T> options = options;
        public T CreateDbContext()
        {
            return (T)Activator.CreateInstance(typeof(T), options)!;
        }
    }
}
