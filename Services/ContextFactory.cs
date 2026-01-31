using Microsoft.EntityFrameworkCore;
using Zin.Services.Interfaces;

namespace Zin.Services
{
    public class ContextFactory<T>(DbContextOptions<T> options) : IContextFactory<T> where T : DbContext
    {
        private readonly DbContextOptions<T> options = options;
        public T CreateDbContext()
        {
            return (T)Activator.CreateInstance(typeof(T), options)!;
        }
    }
}
