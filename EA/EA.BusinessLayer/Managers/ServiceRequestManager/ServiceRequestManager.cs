using System;
using System.Collections.Generic;
using System.Text;
using EA.BusinessLayer.Core;
using EA.Common.BusinessObjects;
using EA.Common.Core;
using EA.DA.Core;
using Microsoft.Extensions.Logging;
using EA.Common.Entities;
using System.Linq;

namespace EA.BusinessLayer.Managers.ServiceRequestManager
{
    public class ServiceRequestManager:BusinessManager,IServiceRequestManager
    {
        IRepository _repository;
        ILogger<ServiceRequestManager> _logger;
        IUnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public ServiceRequestManager(IRepository repository,ILogger<ServiceRequestManager>logger,IUnitOfWork unitOfWork):base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        
        public void Create(BaseEntity entity)
        {
            ServiceRequest serviceRequest = (ServiceRequest)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());
            _repository.Create<ServiceRequest>(serviceRequest);
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        
        public IEnumerable<TenantServiceRequest>GetAllTenantServiceRequests()
        {
            var query = from tenants in _repository.All<Tenant>()
                        join serviceReqs in _repository.All<ServiceRequest>()
                        on tenants.ID equals serviceReqs.TenantID
                        join statues in _repository.All<Status>()
                        on serviceReqs.StatusID equals statues.ID
                        select new TenantServiceRequest()
                        {
                            TenantID = tenants.ID,
                            Description = serviceReqs.Description,
                            Email = tenants.Email,
                            EmployeeComments = serviceReqs.EmployeeComments,
                            Phone = tenants.Phone,
                            Status = statues.Description,
                            TenantName = tenants.Name
                        };
            return query.ToList<TenantServiceRequest>();
        }
    }
}
