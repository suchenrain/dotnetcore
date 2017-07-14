using System;
using System.Collections.Generic;
using System.Text;

namespace EA.DataAccess.Core
{
    public interface IDbFactory
    {
        DataContext GetDataContext { get; }
    }
}
