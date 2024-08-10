using Race_management.Models;

namespace Race_management.Data.PlayerShowData
{
    public interface IPlayerShowData
    {
        public List<Show> GetShowbyUserId(string userId);


    }
}
