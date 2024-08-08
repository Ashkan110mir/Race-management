using Race_management.Data;
using Race_management.Models;

namespace Race_management.Areas.Admin.Data.AdminTeamData
{
    public class AdminTeamData : IAdminTeamData
    {
        private RmContext _db;
        public AdminTeamData(RmContext db)
        {
            _db = db;
        }

        public bool AddTeam(Team team)
        {
            try
            {
                if(team != null)
                {
                    _db.Teams.Add(team);
                    _db.SaveChanges();
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }

        public List<Team> GetAllTeam()
        {
            return _db.Teams.ToList();
        }

        public string GetTeamNameByPlayerId(string playerId)
        {
            return _db.Teams.Where(e => e.Players.Where(e => e.Id == playerId).Any()).Select(e => e.TeamName).FirstOrDefault();
        }

        
    }
}
