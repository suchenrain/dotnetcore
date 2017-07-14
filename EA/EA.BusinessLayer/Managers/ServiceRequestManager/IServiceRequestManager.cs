using System;
using System.Collections.Generic;
using System.Text;
using EA.BusinessLayer.Core;
using EA.Common.BusinessObjects;

namespace EA.BusinessLayer.Managers.ServiceRequestManager
{
    public interface IServiceRequestManager:IActionManager
    {
        IEnumerable<TenantServiceRequest> GetAllTenantServiceRequests();
    }
}
