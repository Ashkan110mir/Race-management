using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Areas.Admin.Data.AdminPlayerData;
using Race_management.Areas.Admin.Data.AdminShowData;
using Race_management.Areas.Admin.Data.AdminTeamData;
using Race_management.Areas.Admin.ViewModel.PlayerManagment;
using Race_management.Data;
using Race_management.Models;

namespace Race_management.Areas.Admin.Controllers
{
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PlayerManagement : Controller
    {
        private IAdminPlayerData _playerdata;
        private IAdminShowData _ShowData;
        private IAdminTeamData _teamdata;
        private UserManager<RmUserIdentity> _usermanager;
        private RmContext _db;

        public PlayerManagement(IAdminPlayerData adminPlayer, IAdminShowData adminShow, IAdminTeamData teamdata, UserManager<RmUserIdentity> usermanaer, RmContext db)
        {
            _playerdata = adminPlayer;
            _ShowData = adminShow;
            _teamdata = teamdata;
            _usermanager = usermanaer;
            _db = db;
        }
        public async Task<IActionResult> Playermanage()
        {
            var vm = new List<PlayerManageViewModel>();
            var getAllPlayer = await _playerdata.GetAllPlayer();
            foreach (var player in getAllPlayer)
            {
                var shows = _ShowData.GetSHowByplayer(player.Id);

                vm.Add(new PlayerManageViewModel()
                {
                    playerName = player.Name,
                    playerId = player.Id,
                    PlayerEmail = player.Email,
                    PlayerLastName = player.LastName,
                    PlayerPhone = player.PhoneNumber,
                    TeamName = _teamdata.GetTeamNameByPlayerId(player.Id),
                    shows = shows,
                });
            }
            return View(vm);
        }

    }
}
