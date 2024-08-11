using Race_management.Models;

namespace Race_management.Data.CoachTeamData
{
    public class CoachTeamData : ICoachTeamData
    {
        private RmContext _db;
        public CoachTeamData(RmContext db)
        {
            _db = db;
        }

        public Team GetTeamById(int Teamid)
        {
            return _db.Teams.Where(e => e.TeamId == Teamid).FirstOrDefault();
        }

        public List<Team> GetTeamsByCoachId(string coachId)
        {
            return _db.Teams.Where(e=>e.CoachId==coachId).ToList();
        }
       
    }
}
