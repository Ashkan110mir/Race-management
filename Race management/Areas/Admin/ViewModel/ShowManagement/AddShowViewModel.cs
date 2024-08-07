using System.ComponentModel.DataAnnotations;

namespace Race_management.Areas.Admin.ViewModel.ShowManagement
{
    public class AddShowViewModel
    {
        //page need
        
        public List<Player_name_id_viewmodel>? Players { get; set; }


        //page Return
        [Display(Name ="عنوان اجرا:")]
        [Required(ErrorMessage ="لطفا عنوان اجرا را وارد کنید.")]
        public string? Title { get; set; }



        [Display(Name = "عنوان اجرا:")]
        [Required(ErrorMessage ="لطفا یک تاریخ انتخاب کنید")]
        public DateTime? DateTime { get; set; }

        [Display(Name = "بازیکن:")]
        public string? SelectedPlayerID { get; set; }


    }
}
