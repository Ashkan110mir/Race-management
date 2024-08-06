using Microsoft.AspNetCore.Identity;

namespace Race_management.Models
{
    public class RmUserIdentity : IdentityUser
    {
        public string? Name { get; set; }

        public string? LastName { get; set; }

        //if user is player
        public Team? PlayerTeam { get; set; }
        public List<Show>? PlayerShows { get; set; }
        //if user is Coach 

        public List<Team>? CoachTeams { get; set; }

        public List<ShowToCoach>? CoachToShow { get; set; }

    }
}
