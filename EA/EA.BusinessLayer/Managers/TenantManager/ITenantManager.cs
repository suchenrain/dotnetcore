using System;
using System.Collections.Generic;
using System.Text;
using EA.Common.Entities;
using EA.BusinessLayer.Core;

namespace EA.BusinessLayer.Managers.TenantManager
{
    public interface ITenantManager:IActionManager
    {
        Tenant GetTenant(long tenantId);
    }
}
