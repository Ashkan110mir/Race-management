using Microsoft.AspNetCore.Identity;
using Race_management.Data;
using Race_management.Models;

namespace Race_management.Areas.Admin.Data.AdminPlayerData
{
    public class AdminPlayerData : IAdminPlayerData
    {
        private RmContext _db;
        private UserManager<RmUserIdentity> _usermanger;
        public AdminPlayerData(RmContext db, UserManager<RmUserIdentity> usermanger)
        {
            _db = db;
            _usermanger = usermanger;
        }
        public async Task<IList<RmUserIdentity>> GetAllPlayer()
        {
            var user = await _usermanger.GetUsersInRoleAsync("Player");
            return user;
        }

        public List<RmUserIdentity> GetPlayersById(List<string> Ids)
        {
            var players = new List<RmUserIdentity>();
            if (Ids.Count() > 0)
            {
                foreach (var id in Ids)
                {
                    players.Add(_db.Users.Where(e => e.Id == id).FirstOrDefault());          
                }
            }
            return players;
        }
        public int PlayersCountByTeam(int teamid)
        {
            int count = _db.Users.Where(e => e.PlayerTeam.TeamId == teamid).Count();
            return count;
        }
    }
}
