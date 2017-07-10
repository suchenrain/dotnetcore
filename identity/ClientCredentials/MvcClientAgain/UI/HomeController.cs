using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcClientAgain.UI
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
