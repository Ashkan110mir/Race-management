using Race_management.Models;

namespace Race_management.ViewModel.CoachDashboard
{
    public class ManagespecificTeamViewModel
    {
        public Team? Team { get; set; }

        public List<RmUserIdentity>? NewPlayers { get; set; }

        public List<RmUserIdentity>? ExistPlayer { get; set; }
    }
}
