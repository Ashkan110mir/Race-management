using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Models;
using System.Security.Claims;

namespace Race_management.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminDashboard : Controller
    {
        private UserManager<RmUserIdentity> _usermanager;
        public AdminDashboard(UserManager<RmUserIdentity> userManager)
        {
            _usermanager = userManager;
        }
        [Route("/Admin")]
        public IActionResult Dashboard()
        {
            var adminname=_usermanager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.UserFullName =adminname.Result.Name+" "+adminname.Result.LastName;
            return View();
        }
    }
}
