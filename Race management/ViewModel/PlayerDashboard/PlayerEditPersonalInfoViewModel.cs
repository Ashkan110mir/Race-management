using System.ComponentModel.DataAnnotations;

namespace Race_management.ViewModel.PlayerDashboard
{
    public class PlayerEditPersonalInfoViewModel
    {
        [Display(Name="نام:")]
        [Required(ErrorMessage ="لطفا نام خود را وارد کنید.")]
        [MaxLength(60)]
        public string? Name {  get; set; }

        [Display(Name = "نام خانوادگی:")]
        [Required(ErrorMessage = "لطفا نام خانوداگی خود را وارد کنید.")]
        [MaxLength(60)]
        public string? LastName { get; set; }

        [Display(Name = "ادرس ایمیل")]
        [Required(ErrorMessage = "لطفا ادرس ایمیل خود را وارد کنید.")]
        [EmailAddress(ErrorMessage ="لطفا یک ایمیل معتبر وارد کنید.")]
        public string? EmailAddress { get; set; }


        [Display(Name = "شماره موبایل:")]
        [Required(ErrorMessage = "لطفا شماره موبایل خود را وارد کنید")]
        [MaxLength(11,ErrorMessage ="شماره موبایل باید 11 رقم باشد")]
        [MinLength(11,ErrorMessage ="شماره موبایل باید 11 رقم باشد.")]
        [Phone(ErrorMessage ="لطفا شماره موبایل معتبر وارد کنید.")]
        public string? PhoneNumber { get;set; }  

         
    }
}
