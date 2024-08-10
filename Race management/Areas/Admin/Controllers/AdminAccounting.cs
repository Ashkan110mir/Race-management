using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Areas.Admin.ViewModel.AdminAccounting;
using Race_management.Models;

namespace Race_management.Areas.Admin.Controllers
{
    [Route("/Admin/[Controller]/[Action]")]
    [Area("Admin")]

    public class AdminAccounting : Controller
    {
        private SignInManager<RmUserIdentity> _signinmanager;
        private UserManager<RmUserIdentity> _usermanager;
        public AdminAccounting(SignInManager<RmUserIdentity> signinmanager, UserManager<RmUserIdentity> userManager)
        {
            _signinmanager = signinmanager;
            _usermanager = userManager;
        }

        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "AdminDashboard");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel information)
        {
            if (!ModelState.IsValid)
            {
                return View(information);
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "AdminDashboard");
            }
            if (User.Identity.IsAuthenticated && !User.IsInRole("Admin"))
            {

                ModelState.AddModelError("", "شما با حساب دیگری وارد شدید.");
                return View(information);
            }
            //chack if username and password is for admin not user
            var user = new RmUserIdentity();
            user.Id = _usermanager.Users.Where(e => e.UserName == information.UserName).Select(e => e.Id).FirstOrDefault();
            bool IsUserIsAdmin=false;
            if (user != null)
            {
                IsUserIsAdmin = await _usermanager.IsInRoleAsync(user, "Admin");
            }
            //user exist and its admin
            if (IsUserIsAdmin)
            {
                var loginresult = await _signinmanager.PasswordSignInAsync(information.UserName, information.Password, information.RememberMe, true);
                if (loginresult.Succeeded)
                {
                    return RedirectToAction("Dashboard", "AdminDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "نام کاربری یا رمز عبور درست نیست");
                    return View(information);
                }
            }
            //user exist but not admin
            else
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبور درست نیست");
                return View(information);
            }
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
