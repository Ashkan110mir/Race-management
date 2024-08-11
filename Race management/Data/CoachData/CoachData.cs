using Race_management.Models;

namespace Race_management.Data.CoachData
{
    public class CoachData : ICoachData
    {
        private RmContext _db;
        public CoachData(RmContext db)
        {
            _db = db;
        }

        public bool EditCoach(string Coachid, RmUserIdentity NewCoach)
        {
            try
            {
                var preuser = _db.Users.Where(e => e.Id == Coachid).FirstOrDefault();
                if (preuser != null)
                {
                    preuser.Name = NewCoach.Name;
                    preuser.LastName=NewCoach.LastName;
                    preuser.Email=NewCoach.Email;
                    preuser.PhoneNumber=NewCoach.PhoneNumber;
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

        public List <string> GetCoachNameWithShowId(int showid)
        {
            return _db.Users.Where(e=>e.CoachToShow.Where(e=>e.ShowId==showid).Any()).Select(e=>e.Name+" "+e.LastName+" "+"(نمره:"+e.CoachToShow.Where(e=>e.ShowId==showid && e.Coachid==e.Coachid).Select(e=>e.score).FirstOrDefault()+")").ToList();
        }
    }
}
