using Microsoft.EntityFrameworkCore;
using Race_management.Models;

namespace Race_management.Data.ICoachShowData
{
    public class CoachShowData : ICoachShowData
    {
        public RmContext _db;

        public CoachShowData(RmContext db)
        {
            _db = db;
        }

        public bool AddRate(int showid, string Coachid, int score)
        {
            try
            {
                if (showid != 0 && Coachid != null && score >= 0 && score <= 20)
                {
                    var show = _db.Shows.Where(e => e.ShowId == showid).Include(e => e.ShowToCoach.Where(e => e.Coachid == Coachid)).FirstOrDefault();
                    var showtocoach = new ShowToCoach()
                    {
                        Coachid = Coachid,
                        score = score,
                        ShowId = showid,
                    };
                    show.ShowToCoach.Add(showtocoach);
                    _db.SaveChanges();
                    var average = (int)_db.ShowToCoache.Where(e => e.ShowId == showid).Select(e => e.score).Average();
                    show.AverageScore = average;
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

        public List<Show> GetAllUnRatedByCoachShow(string CoachId)
        {
            var a = _db.Shows.Where(e => e.ShowToCoach == null || e.ShowToCoach.Any(e => e.Coachid == CoachId) == false).Include(e => e.ShowPlayer).ToList();
            return a;
        }



    }
}
