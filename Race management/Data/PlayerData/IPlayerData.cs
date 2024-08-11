using Race_management.Models;

namespace Race_management.Data.PlayerData
{
    public interface IPlayerData
    {
        public bool EditPlayer(string userid,RmUserIdentity newplayer);
    }
}

