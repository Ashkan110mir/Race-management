using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Models;
using System.Security.Claims;

namespace Race_management.Controllers
{
    [Authorize (Roles ="Coach")]
    public class CoachDashboard : Controller
    {
        private UserManager<RmUserIdentity> _usermanager;
        public CoachDashboard(UserManager<RmUserIdentity> usermanager)
        {
            _usermanager = usermanager;
        }
        public async Task <IActionResult> Coachdashboard()
        {
            var user=await _usermanager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(user);
        }

        public IActionResult AddRatingToShows()
        {
            return View();
        }
    }
}
