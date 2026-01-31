using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Zin.Utils
{
    public record DatabaseInfo(string ConnectionString, DbProviderFactory DbProvider);
}
