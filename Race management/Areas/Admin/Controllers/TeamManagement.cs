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
            vm.Coach = (List<RmUserIdentity>)await _adminCoachdata.GetAllCoach();
            ViewBag.isadd = 1;
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

        public IActionResult DeleteTeam(int teamid)
        {
            if (teamid != 0)
            {
                var deletestatus = _adminTeamData.RemoveTeam(teamid);
                if (deletestatus)
                {
                    return RedirectToAction(nameof(TeamManage));
                }
                else
                {
                    ViewBag.massage = "خطایی در حذف رخ داد";
                    return View();
                }
            }
            return View();
        }

        public async Task<IActionResult> EditTeam(int teamid)
        {
            if (teamid != 0)
            {
                var selectedteam = new AddTeamViewModel();
                var team = _adminTeamData.GetTeamById(teamid);
                if (team == null)
                {
                    return NotFound();
                }
                selectedteam.Coach = (List<RmUserIdentity>)await _adminCoachdata.GetAllCoach();
                selectedteam.TeamName = team.TeamName;
                selectedteam.SelectedCoachId = team.CoachId;
                ViewBag.id = teamid;
                ViewBag.isadd = 0;
                return View("AddTeam", selectedteam);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditTeam(AddTeamViewModel EditTeam, int teamid)
        {
            if (ModelState.IsValid)
            {
                var team = new Team()
                {
                    TeamName = EditTeam.TeamName,
                    TeamId = teamid,
                    CoachId = EditTeam.SelectedCoachId

                };
                bool editstatus = _adminTeamData.EditTeam(team, team.TeamId);
                if (editstatus)
                {
                    return RedirectToAction(nameof(TeamManage));
                }
                else
                {
                    ModelState.AddModelError("", "مشکلی در ویرایش رخ داد");
                    EditTeam.Coach = (List<RmUserIdentity>)await _adminCoachdata.GetAllCoach();
                    return View("AddTeam", EditTeam);
                }
            }
            else
            {
                EditTeam.Coach = (List<RmUserIdentity>)await _adminCoachdata.GetAllCoach();
                return View("AddTeam", EditTeam);
            }
        }
    }
}
