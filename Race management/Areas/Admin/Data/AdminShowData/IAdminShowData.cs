using Race_management.Models;

namespace Race_management.Areas.Admin.Data.AdminShowData
{
    public interface IAdminShowData
    {
        public List<Show> GetAllShow();
        public bool AddShow(Show newshow);
        public bool RemoveShow(int Showid);

        public Show GetShowById(int Showid);

        public bool EditShow(Show newshow);
        public List<Show> GetSHowByplayer(string playerid);

        public List<Show> SearchShow(int? id, string? title, DateTime? datefrom, DateTime? dateto, string? Player, string orderby);


    }
}
