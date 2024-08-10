using Microsoft.AspNetCore.Mvc;

namespace Race_management.Controllers
{
    public class Error : Controller
    {
        public IActionResult AccessDenied()
        {
            return View("Views/Shared/AccessDenied.cshtml");
        }
        public IActionResult Notfound()
        {
            return View("Views/Shared/NotFound.cshtml");
        }
    }
}
