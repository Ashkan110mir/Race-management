using Microsoft.AspNetCore.Mvc;
using Race_management.Utility.ReCaptcha;
using Race_management.ViewModel.UserAccounting;

namespace Race_management.Controllers
{
    public class UserAccounting : Controller
    {
        private IGoogleRecatcha _recaptcha;
        public UserAccounting(IGoogleRecatcha recaptcha)
        {
            _recaptcha = recaptcha;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newuser)
        {
            if (ModelState.IsValid)
            {
                if (!await _recaptcha.ISRecapthaTrue())
                {
                    ModelState.AddModelError("", "لطفا برای ادامه کپچا گوگل را کامل کنید.");
                    return View(newuser);
                }
                return View();
            }
            else

            {
                return View(newuser);
            }
        }
    }
}
