namespace Race_management.Data.CoachData
{
    public class CoachData : ICoachData
    {
        private RmContext _db;
        public CoachData(RmContext db)
        {
            _db = db;
        }
        public List <string> GetCoachNameWithShowId(int showid)
        {
            return _db.Users.Where(e=>e.CoachToShow.Where(e=>e.ShowId==showid).Any()).Select(e=>e.Name+" "+e.LastName+" "+"(نمره:"+e.CoachToShow.Where(e=>e.ShowId==showid && e.Coachid==e.Coachid).Select(e=>e.score).FirstOrDefault()+")").ToList();
        }
    }
}
