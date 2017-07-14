using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EA.BusinessLayer.Managers.ServiceRequestManager;
using Microsoft.Extensions.Logging;
using EA.ServiceApp.Filters;
using EA.Common.BusinessObjects;
using EA.Common.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EA.ServiceApp.Controllers
{
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class ServiceRequestController : BaseController
    {
        IServiceRequestManager _manager;
        ILogger<ServiceRequestController> _logger;

        public ServiceRequestController(IServiceRequestManager manager,ILogger<ServiceRequestController> logger):base(manager,logger)
        {
            _manager = manager;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<TenantServiceRequest>GetTenantsRequests()
        {
            return _manager.GetAllTenantServiceRequests();
        }
        [TransactionActionFilter]
        [HttpPost]
        public void Post(ServiceRequest serviceRequest)
        {
            try
            {
                _manager.Create(serviceRequest);
            }
            catch(Exception ex)
            {
                LogException(ex);
            }
        }
    }
}
