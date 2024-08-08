using Race_management.Data;

namespace Race_management.Areas.Admin.Data.AdminTeamData
{
    public class AdminTeamData : IAdminTeamData
    {
        private RmContext _db;
        public AdminTeamData(RmContext db)
        {
            _db = db;
        }
        public string GetTeamNameByPlayerId(string playerId)
        {
            return _db.Teams.Where(e => e.Players.Where(e => e.Id == playerId).Any()).Select(e => e.TeamName).FirstOrDefault();
        }
    }
}
