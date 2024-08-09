using Race_management.Areas.Admin.ViewModel.ShowManagement;
using Race_management.Models;
using System.ComponentModel.DataAnnotations;

namespace Race_management.Areas.Admin.ViewModel.TeamManagement
{
    public class AddTeamViewModel
    {
        //view need
        public List<RmUserIdentity>? Players { get; set; }

        public List<RmUserIdentity>? Coach { get; set; }

        //admin send to server
        [Display(Name ="نام تیم:")]
        [Required(ErrorMessage ="لطفا یک نام برای تیم انتخاب کنید")]
        [MaxLength(60)]
        public string? TeamName { get; set; }

        [Display(Name ="مربی تیم:")]
        [Required(ErrorMessage ="لطفا مربی تیم را انتخاب کنید.")]
        public string? SelectedCoachId { get; set; }
    }
}
