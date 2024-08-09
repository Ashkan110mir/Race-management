using System.ComponentModel.DataAnnotations;

namespace Race_management.ViewModel.UserAccounting
{
    public class LogInViewModel
    {
        [Display(Name = "نام کاربری یا ایمیل:")]
        [Required(ErrorMessage = "لطفا نام کاربری یا ایمیل خود را وارد کنید.")]
        public string? UserNameOrEmail { get; set; }

        [Display(Name = "رمز عبور:")]
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
