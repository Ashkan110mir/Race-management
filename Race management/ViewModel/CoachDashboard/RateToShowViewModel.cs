using Race_management.Models;
using System.ComponentModel.DataAnnotations;

namespace Race_management.ViewModel.CoachDashboard
{
    public class RateToShowViewModel
    {
        public Show? show { get; set; }


        //get from coach

        [Required(ErrorMessage ="لطفا یک نمره برای این اجرا وارد کنید ")]
        [Display(Name ="نمره اجرا:")]
        [Range(0, 20, ErrorMessage = "مقدار باید بین 0 تا 20 باشد.")]
        public int? CoachScore { get; set; }

    }
}
