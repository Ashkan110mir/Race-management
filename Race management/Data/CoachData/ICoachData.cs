using Race_management.Models;

namespace Race_management.Data.CoachData
{
    public interface ICoachData
    {
        public List<string> GetCoachNameWithShowId(int showid);

        public bool EditCoach(string Coachid, RmUserIdentity NewCoach);
    }
}
