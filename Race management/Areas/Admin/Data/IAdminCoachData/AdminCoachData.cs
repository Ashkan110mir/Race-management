using Microsoft.AspNetCore.Identity;
using Race_management.Data;
using Race_management.Models;

namespace Race_management.Areas.Admin.Data.IAdminCoachData
{
    public class AdminCoachData : IAdminCoachData
    {
        private RmContext _db;
        private UserManager<RmUserIdentity> _usermanaer;

        public AdminCoachData(RmContext db,UserManager<RmUserIdentity> userManager)
        {
            _db = db;
            _usermanaer = userManager;
        }

        public async Task<IList<RmUserIdentity>> GetAllCoach()
        {
            return await _usermanaer.GetUsersInRoleAsync("Coach");
        }

        public async Task <string>  GetCoachNameByTeam(int Teamid)
        {
            var coach =await _usermanaer.GetUsersInRoleAsync("Coach");
            var teamcoach= coach.Where(e => e.CoachTeams.Where(e => e.TeamId == Teamid).Any()).Select(e => new {e.Name,e.LastName}).FirstOrDefault();
            return teamcoach.Name + " " + teamcoach.LastName;
        }
    }
}
