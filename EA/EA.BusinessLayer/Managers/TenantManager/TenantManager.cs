using EA.BusinessLayer.Core;
using EA.Common.Core;
using EA.Common.Entities;
using EA.Common.Facade;
using EA.DA.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EA.BusinessLayer.Managers.TenantManager
{
    public class TenantManager : BusinessManager, ITenantManager
    {
        private IRepository _repository;
        private ILogger<TenantManager> _logger;
        private IUnitOfWork _unitOfWork;

        public TenantManager(IRepository repository, ILogger<TenantManager> logger, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Create(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());
            _repository.Create<Tenant>(tenant);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<Tenant>(tenant);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Tenant>().ToList<Tenant>();
        }

        public virtual Tenant GetTenant(long tenantId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The tenant is " + tenantId);
                return _repository.All<Tenant>().Where(i => i.ID == tenantId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Update<Tenant>(tenant);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }
    }
}