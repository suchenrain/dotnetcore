using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EA.BusinessLayer.Core;
using Microsoft.EntityFrameworkCore.Storage;
using EA.ServiceApp.Controllers;

namespace EA.ServiceApp.Filters
{
    public class TransactionActionFilter:ActionFilterAttribute
    {
        IDbContextTransaction transaction;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ((BaseController)context.Controller).ActionManager.UnitOfWork.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception!=null)
            {
                ((BaseController)context.Controller).ActionManager.UnitOfWork.RollbackTransaction();

            }
            else
            {
                ((BaseController)context.Controller).ActionManager.UnitOfWork.CommitTransaction();
            }
        }
        
    }
}
