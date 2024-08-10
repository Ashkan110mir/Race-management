using Race_management.Models;

namespace Race_management.Data.ICoachShowData
{
    public interface ICoachShowData
    {
        public List<Show> GetAllUnRatedByCoachShow(string CoachId);

        public bool AddRate(int showid, string Coachid,int score);
    }
}
