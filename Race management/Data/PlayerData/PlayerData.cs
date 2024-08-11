using Microsoft.AspNetCore.Identity;
using Race_management.Models;
using System.Drawing.Printing;

namespace Race_management.Data.PlayerData
{
    public class PlayerData : IPlayerData
    {
        private RmContext _db;
        private UserManager<RmUserIdentity> _userManager;
        public PlayerData(RmContext db, UserManager<RmUserIdentity> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public bool AddPlayerToTeam(string Playerid, int teamid)
        {
            try
            {
                var user = _userManager.Users.Where(e => e.Id == Playerid).FirstOrDefault();
                if (user == null)
                {
                    return false;

                }
                var team = _db.Teams.Where(e => e.TeamId == teamid).FirstOrDefault();
                user.PlayerTeam = team;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeletePlayerToTeam(string Playerid, int teamid)
        {
            try
            {
                var team = _db.Teams.Where(e => e.TeamId == teamid).FirstOrDefault();

                var user =_userManager.Users.Where(e=>e.Id==Playerid && e.PlayerTeam== team).FirstOrDefault();
                if(user == null || team==null)
                {
                    return false;
                }
                user.PlayerTeam = null;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool EditPlayer(string userid, RmUserIdentity newplayer)
        {
            try
            {
                var Preuser = _db.Users.Where(e => e.Id == userid).FirstOrDefault();
                if (Preuser != null)
                {
                    Preuser.LastName = newplayer.LastName;
                    Preuser.Name = newplayer.Name;
                    Preuser.PhoneNumber = newplayer.PhoneNumber;
                    Preuser.Email = newplayer.Email;
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<RmUserIdentity>> GetAllPlayerWithoutTeam()
        {
            var player =await _userManager.GetUsersInRoleAsync("Player");
            player = player.Where(e => e.TeamID == null).ToList();
            return player;

        }
        public List<RmUserIdentity> GetPlayerByTeam(int Teamid)
        {
            return _db.Users.Where(e => e.PlayerTeam.TeamId == Teamid).ToList();
        }

        public string PlayerTeamNameById(string Id)
        {
            return _db.Users.Where(e => e.Id == Id).Select(e => e.PlayerTeam.TeamName).FirstOrDefault();
        }
    }
}
