using Race_management.Models;

namespace Race_management.Areas.Admin.Data.IAdminCoachData
{
    public interface IAdminCoachData
    {
        public Task<string> GetCoachNameByTeam(int Teamid);
        public Task<IList<RmUserIdentity>> GetAllCoach();
    }
}
