using Race_management.Models;

namespace Race_management.Areas.Admin.ViewModel.PlayerManagment
{
    public class PlayerManageViewModel
    {
        public string? playerId { get; set; }

        public string? playerName { get; set; }

        public string? PlayerLastName { get; set; }

        public string? PlayerEmail { get; set; }

        public string? PlayerPhone { get; set;}

        public string? TeamName { get; set; }
        public List<Show>? shows { get; set; }
        
        
    }
}
