using System;
using System.Collections.Generic;
using System.Text;

namespace EA.DA.Core
{
    public interface IDbFactory
    {
        DataContext GetDataContext { get; }
    }
}
