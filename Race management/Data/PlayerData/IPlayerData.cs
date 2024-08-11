using Race_management.Models;

namespace Race_management.Data.PlayerData
{
    public interface IPlayerData
    {
        public bool EditPlayer(string userid,RmUserIdentity newplayer);
        public  Task<IList<RmUserIdentity>> GetAllPlayerWithoutTeam();
        public List<RmUserIdentity> GetPlayerByTeam(int Teamid);

        public string PlayerTeamNameById(string Id);

        public bool AddPlayerToTeam(string Playerid, int teamid);

        public bool DeletePlayerToTeam(string Playerid, int teamid);
    }
}

