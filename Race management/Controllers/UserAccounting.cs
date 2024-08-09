using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Models;
using Race_management.Utility.Email_Sender;
using Race_management.Utility.ReCaptcha;
using Race_management.ViewModel.UserAccounting;

namespace Race_management.Controllers
{
    public class UserAccounting : Controller
    {
        private IGoogleRecatcha _recaptcha;
        private UserManager<RmUserIdentity> _usermanager;
        private IEmailSender _emailSender;
        public UserAccounting(IGoogleRecatcha recaptcha, UserManager<RmUserIdentity> userManager, IEmailSender emailSender)
        {
            _recaptcha = recaptcha;
            _usermanager = userManager;
            _emailSender = emailSender;
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
                //recaptacha not complete
                if (!await _recaptcha.ISRecapthaTrue())
                {
                    ModelState.AddModelError("", "لطفا برای ادامه کپچا گوگل را کامل کنید.");
                    return View(newuser);
                }
                var user = new RmUserIdentity()
                {
                    Name = newuser.Name,
                    LastName = newuser.LastName,
                    UserName = newuser.Username,
                    Email = newuser.Email,
                    PhoneNumber = newuser.phoneNumer,
                    EmailConfirmed=false,
                    PhoneNumberConfirmed=true,
                };
                var createUserResult = await _usermanager.CreateAsync(user, newuser.Password);            
                if (createUserResult.Succeeded)
                {
                    var addtorole = await _usermanager.AddToRoleAsync(user, "Player");
                    if (addtorole.Succeeded)
                    {
                        string token = await _usermanager.GenerateEmailConfirmationTokenAsync(user);
                        string url = Url.ActionLink("ConfirmEmail", "UserAccounting", new { Username = user.UserName, token = token });
                        string text = $"<!DOCTYPE html>\r\n<html>\r\n<body>\r\n    <header style=\"width: 100%; background-color: orange; color:white;text-align: center; font-size: 200%;\">مسابقات\r\n    </header>\r\n    <div style=\"text-align: center;\">\r\n        <p>خوش آمدید لطفا از طریق لینک زیر ایمیل خود را تایید کنید.</p>\r\n        <p>{url}</p>\r\n    </div>\r\n</body>\r\n</html>";
                        await _emailSender.Send_Email(user.Email, text, "تایید ایمیل", true);
                        ViewBag.massage = "ثبت نام با موفقیت انجام شد لطفا از طریق لینک ارسالی ایمیل خود را تایید کنید در صورت عدم وجود ایمیل لطفا پوشه اسپم خود را نیز چک کنید..";
                        return View();
                    }
                    else
                    {
                        foreach (var error in addtorole.Errors)
                        {
                            ModelState.AddModelError("",error.Description);
                        }
                        return View(newuser);

                    }
                }
                else
                {
                    foreach (var error in createUserResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);               
                    }
                    return View(newuser);
                }
            }
            else

            {
                return View(newuser);
            }
        }
        public async Task<IActionResult> ConfirmEmail(string Username, string token)
        {
            if(Username!=null&& token!=null)
            {
                var user= await _usermanager.FindByNameAsync(Username);
                if(user!=null)
                {
                  var confirmemail= await _usermanager.ConfirmEmailAsync(user, token);
                    if(confirmemail.Succeeded)
                    {
                        ViewBag.massage = "تایید ایمیل با موفقیت انجام شد.";
                        return View(nameof(Register));
                    }
                    else
                    {
                        return NotFound();
                    }
                    
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        #region Check email and username not in used
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IsUserNameInUse(string Username)
        {
            var user = _usermanager.FindByNameAsync(Username).Result;
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json("نام کاربری تکراری است");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IsEmailInuse(string Email)
        {
            var user = _usermanager.FindByEmailAsync(Email).Result;
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json("ایمیل تکراری است");
            }
        }
        #endregion
    }
}
