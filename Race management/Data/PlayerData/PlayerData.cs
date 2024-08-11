using Race_management.Models;
using System.Drawing.Printing;

namespace Race_management.Data.PlayerData
{
    public class PlayerData : IPlayerData
    {
        private RmContext _db;
        public PlayerData(RmContext db)
        {
            _db = db;
        }
        public bool EditPlayer(string userid,RmUserIdentity newplayer)
        {
            var Preuser=_db.Users.Where(e=>e.Id== userid).FirstOrDefault();
            if(Preuser != null)
            {
                Preuser.LastName = newplayer.LastName;
                Preuser.Name= newplayer.Name;
                Preuser.PhoneNumber = newplayer.PhoneNumber;
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
