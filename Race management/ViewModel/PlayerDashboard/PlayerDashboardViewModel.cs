using Race_management.Models;

namespace Race_management.ViewModel.PlayerDashboard
{
    public class PlayerDashboardViewModel
    {
        public string? Name {  get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public List<PlayerShowForDashboardViewModel>? PlayerShow {  get; set; }


    }
}
