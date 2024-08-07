using Race_management.Models;

namespace Race_management.Areas.Admin.Data.AdminPlayerData
{
    public interface IAdminPlayerData
    {
       public Task<IList<RmUserIdentity>> GetAllPlayer();
    }
}
