using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Race_management.Data.IPlayerCoachData
{
    public class PlayerCoachData : IPlayerCoachData
    {
        private RmContext _db;
        public PlayerCoachData(RmContext db)
        {
            _db = db;
        }
        public List<string> GetCoachNameByShow(int Showid)
        {
            return _db.Users.Where(e=>e.CoachToShow.Where(e=>e.ShowId==Showid).Any()).Select(e=>e.Name+" "+e.LastName).ToList(); 
        }
    }
}
