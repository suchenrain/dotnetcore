﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EA.DA.Core
{
    public class UnitOfWork:IUnitOfWork
    {
        private IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public void BeginTransaction()
        {
            _dbFactory.GetDataContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _dbFactory.GetDataContext.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            _dbFactory.GetDataContext.Database.CommitTransaction();
        }

        public void SaveChanges()
        {
            _dbFactory.GetDataContext.Save();
        }
        
    }
}
