using Microsoft.AspNetCore.Mvc;

namespace Maxim.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
