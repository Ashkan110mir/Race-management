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
        public AdminAccounting(SignInManager<RmUserIdentity> signinmanager)
        {
            _signinmanager = signinmanager;
        }

        public IActionResult Login()
        {
           
            if(User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "AdminDashboard");
            }       
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel information)
        {
            if(!ModelState.IsValid)
            {
                return View(information);
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "AdminDashboard");
            }
            if(User.Identity.IsAuthenticated && !User.IsInRole("Admin"))
            {

                ModelState.AddModelError("", "شما با حساب دیگری وارد شدید.");
                return View(information);
            }
            //user not login and all field are complete
            var loginresult = await _signinmanager.PasswordSignInAsync(information.UserName, information.Password, information.RememberMe, true);
            if(loginresult.Succeeded)
            {
                return RedirectToAction("Dashboard", "AdminDashboard");
            }
            else
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبور درست نیست");
                return View(information);
            }
        }



        [Authorize(Roles ="Admin")]
        public async Task <IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
