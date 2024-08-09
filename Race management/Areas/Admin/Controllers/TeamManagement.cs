using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Race_management.Areas.Admin.Data.AdminPlayerData;
using Race_management.Areas.Admin.Data.AdminTeamData;
using Race_management.Areas.Admin.Data.IAdminCoachData;
using Race_management.Areas.Admin.ViewModel.PlayerManagment;
using Race_management.Areas.Admin.ViewModel.TeamManagement;
using Race_management.Models;

namespace Race_management.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Area("Admin")]
    public class TeamManagement : Controller
    {
        private IAdminTeamData _adminTeamData;
        private IAdminCoachData _adminCoachdata;
        private IAdminPlayerData _adminPlayerData;
        public TeamManagement(IAdminTeamData adminTeamData, IAdminCoachData adminCoachData, IAdminPlayerData adminPlayerData)
        {
            _adminTeamData = adminTeamData;
            _adminCoachdata = adminCoachData;
            _adminPlayerData = adminPlayerData;
        }
        public async Task<IActionResult> TeamManage()
        {
            var vm = new List<TeamManageViewModel>();
            var teams = _adminTeamData.GetAllTeam();
            foreach (var team in teams)
            {
                vm.Add(new TeamManageViewModel()
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    CoachName = await _adminCoachdata.GetCoachNameByTeam(team.TeamId),
                    PlayerCount = _adminPlayerData.PlayersCountByTeam(team.TeamId),
                });
            }
            return View(vm);
        }
        public async Task<IActionResult> AddTeam()
        {
            AddTeamViewModel vm = new AddTeamViewModel();
            vm.Players = (List<Models.RmUserIdentity>?)await _adminPlayerData.GetAllPlayer();
            vm.Coach = (List<RmUserIdentity>)await _adminCoachdata.GetAllCoach();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(AddTeamViewModel newTeam)
        {
            if (ModelState.IsValid)
            {
                var team = new Team()
                {
                    TeamName = newTeam.TeamName,
                    CoachId = newTeam.SelectedCoachId,

                };
                var getplayer = new List<RmUserIdentity>();
                var addstatus = _adminTeamData.AddTeam(team);
                if (addstatus)
                {
                    return RedirectToAction(nameof(TeamManage));
                }
                else
                {
                    ModelState.AddModelError("", "خطایی در افزودن تیم رخ داد.");
                    return View(team);
                }
            }
            return View();
        }
    }
}
