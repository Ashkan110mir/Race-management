using Race_management.Models;

namespace Race_management.Areas.Admin.Data.AdminTeamData
{
    public interface IAdminTeamData
    {
        public string GetTeamNameByPlayerId(string playerId);

        public List<Team> GetAllTeam();

        public bool AddTeam(Team team);

        public bool RemoveTeam(int id);

        public Team GetTeamById(int teamId);

        public bool EditTeam(Team newteam,int id);
    }
}
