using Microsoft.EntityFrameworkCore;
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
                        preshow.ShowTitle = newshow.ShowTitle;
                        preshow.ShowDate = newshow.ShowDate;
                        preshow.ShowplayerId = newshow.ShowplayerId;
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

        public List<Show> GetSHowByplayer(string playerid)
        {
            return _db.Shows.Where(e => e.ShowplayerId == playerid && e.Isactive == true).ToList();
        }

        public List<Show> SearchShow(int? id, string? title, DateTime? datefrom, DateTime? dateto,string? Player, string orderby)
        {
            IQueryable<Show> Shows = _db.Shows;
            if (id!=0)
            {
                Shows = Shows.Where(e => e.ShowId == id);
            }
            if (title != null)
            {
                Shows = Shows.Where(e => e.ShowTitle.Contains(title));
            }
            if (datefrom != null)
            {
                Shows = Shows.Where(e => e.ShowDate >= datefrom);
            }
            if (dateto != null)
            {
                Shows = Shows.Where(e => e.ShowDate <= dateto);
            }
            if(Player!=null)
            {
                Shows = Shows.Where(e => e.ShowPlayer.Name.Contains(Player) || e.ShowPlayer.LastName.Contains(Player) || (e.ShowPlayer.Name+" "+e.ShowPlayer.LastName).Contains(Player));
            }
            switch (orderby)
            {
                case "OrderByDate":
                    {
                        Shows = Shows.OrderBy(e => e.ShowDate);
                        break;
                    }
                case "OrderByName":
                    {
                        Shows = Shows.OrderBy(e => e.ShowTitle);
                        break;
                    }
                case "OrderById":
                    {
                        Shows = Shows.OrderBy(e => e.ShowId);
                        break;
                    }
            }
            //return Shows.ToList();
            

            return Shows.Include(e => e.ShowPlayer).ToList();

        }
    }
}
