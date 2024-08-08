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
            return _db.Shows.Where(e => e.Isactive == true).ToList();
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

        public bool RemoveShow(int Showid)
        {
            try
            {
                var show = _db.Shows.Where(e => e.ShowId == Showid).FirstOrDefault();
                if (show != null)
                {
                    show.Isactive = false;
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

        public Show GetShowById(int Showid)
        {
            return _db.Shows.Where(e => e.ShowId == Showid && e.Isactive == true).FirstOrDefault();
        }

        public bool EditShow(Show newshow)
        {
            try
            {
                if (newshow.ShowDate != null && newshow.ShowTitle != null && newshow.ShowplayerId != null)
                {
                    var preshow = _db.Shows.Where(e => e.ShowId == newshow.ShowId).FirstOrDefault();
                    if (preshow != null)
                    {
                        preshow.ShowTitle=newshow.ShowTitle;
                        preshow.ShowDate = newshow.ShowDate;
                        preshow.ShowplayerId= newshow.ShowplayerId;
                        _db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
