using EA.BusinessLayer.Core;
using EA.Common.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EA.ServiceApp.Controllers
{
    public class BaseController : Controller
    {
        private IActionManager _manager;
        private ILogger _logger;

        public BaseController(IActionManager manager, ILogger logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public IActionManager ActionManager { get { return _manager; } }
        public ILogger Logger { get { return _logger; } }

        public void LogException(Exception ex)
        {
            string errorMessage = LoggerHelper.GetExceptionDetails(ex);
            _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, errorMessage);
        }
    }
}