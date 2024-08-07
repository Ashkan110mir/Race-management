using System.ComponentModel.DataAnnotations;

namespace Race_management.Areas.Admin.ViewModel.AdminAccounting
{
    public class LoginViewModel
    {
        [Display(Name="نام کاربری:")]
        [Required(ErrorMessage ="لطفا نام کاربری را وارد کنید.")]
        
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="لطفا رمز عبور را وارد کنید")]
        [Display(Name ="رمز عبور:")]
        public string? Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
