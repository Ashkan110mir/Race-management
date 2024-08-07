namespace Race_management.Areas.Admin.ViewModel.ShowManagement
{
    public class ShowManagementViewModel
    {
        public int Id { get; set; }

        public string? title { get; set; }

        public DateTime date { get; set; }

        public int Score { get; set; }

        public Player_name_id_viewmodel? PlayerNames { get; set; }
        
    }
}
