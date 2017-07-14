using System;
using System.Collections.Generic;
using System.Text;

namespace EA.DataAccess.Core
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void SaveChanges();
    }
}
