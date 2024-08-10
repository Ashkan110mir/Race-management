using Race_management.Models;

namespace Race_management.Data.PlayerShowData
{
    public class PlayerShowData : IPlayerShowData
    {
        private RmContext _db;
        public PlayerShowData(RmContext db)
        {
            _db = db;
        }



        public List<Show> GetShowbyUserId(string userId)
        {
            return _db.Shows.Where(e=>e.ShowplayerId == userId).ToList();
        }
    }
}
