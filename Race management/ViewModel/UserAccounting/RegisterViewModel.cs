using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Race_management.ViewModel.UserAccounting
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="لطفا نام خود را وارد کنید")]
        [Display(Name ="نام:")]
        [MaxLength(60)]
        public string? Name {  get; set; }


        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد کنید.")]
        [Display(Name = "نام خانوداگی:")]
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        [Display(Name = "نام کاربرِی:")]
        //[Remote()]
        public string? Username { get; set; }


        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید.")]
        [Display(Name = "رمز عبور:")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        [Required(ErrorMessage = "لطفا تکرار رمز عبور را وارد کنید.")]
        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="رمز عبور با تکرار رمز عبور مطابقت ندارد")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید.")]
        [Display(Name = "ایمیل:", Prompt = "xxxxxx@xxxx.xxx")]
        [EmailAddress(ErrorMessage ="لطفا یک ایمیل معتبر وارد کنید")]
        //[Remote]
        public string? Email { get; set; }


        [Required(ErrorMessage = "لطفا شماره تلفن خود را وارد کنید.")]
        [Display(Name = "شماره تلفن:",Prompt ="09xxxxxxxxx")]
        [Phone(ErrorMessage = "لطفا شماره تلفن معتبر وارد کنید")]
        [MinLength(11, ErrorMessage = "حداقل طول شماره تلفن باید 11 عدد باشد")]
        [MaxLength(11,ErrorMessage ="حداکثر طول تلفن باید 11 عدد باشد")]
        public string? phoneNumer {  get; set; }


    }
}
