using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zin.Services.Interfaces
{
    public interface IDbContextFactory<T> where T : DbContext
    {
        T Create();

    }
}
