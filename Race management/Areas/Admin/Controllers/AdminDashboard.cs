using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Race_management.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboard : Controller
    {
        [Route("/Admin")]
        public IActionResult Dashboarrd()
        {
            return View();
        }
    }
}
