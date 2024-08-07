using Race_management.Data;
using Race_management.Models;

namespace Race_management.Areas.Admin.Data.AdminShowData
{
    public class AdminShowData : IAdminShowData
    {
        private RmContext _db;
        public AdminShowData(RmContext db)
        {
            _db = db;
        }
        public List<Show> GetAllShow()
        {
            return _db.Shows.ToList();
        }
        public bool AddShow(Show newshow)
        {
            try
            {
                if (newshow != null)
                {
                    _db.Shows.Add(newshow);
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
    }
}
