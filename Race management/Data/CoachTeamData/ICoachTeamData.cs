using Race_management.Models;

namespace Race_management.Data.CoachTeamData
{
    public interface ICoachTeamData
    {
        public List<Team> GetTeamsByCoachId(string coachId);

        public Team GetTeamById(int Teamid);

        
    }
}
