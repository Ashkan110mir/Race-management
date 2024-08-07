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
    }
}
