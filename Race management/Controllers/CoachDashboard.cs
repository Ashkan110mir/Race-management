using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Data.CoachData;
using Race_management.Data.CoachTeamData;
using Race_management.Data.ICoachShowData;
using Race_management.Data.PlayerData;
using Race_management.Data.PlayerShowData;
using Race_management.Models;
using Race_management.Utility;
using Race_management.ViewModel.CoachDashboard;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace Race_management.Controllers
{
    [Authorize(Roles = "Coach")]
    public class CoachDashboard : Controller
    {
        private UserManager<RmUserIdentity> _usermanager;
        private IPlayerShowData _playershowdata;
        private ICoachShowData _coachshowdata;
        private ICoachData _coachdata;
        private ICoachTeamData _coachteamdata;
        private IPlayerData _playerdata;
        public CoachDashboard(UserManager<RmUserIdentity> usermanager, ICoachShowData coachShowData, IPlayerShowData playershowData, ICoachData coachdata, ICoachTeamData coachteamdata, IPlayerData playerData)
        {
            _usermanager = usermanager;
            _coachshowdata = coachShowData;
            _playershowdata = playershowData;
            _coachdata = coachdata;
            _coachteamdata = coachteamdata;
            _playerdata = playerData;
        }
        public List<RateToShowViewModel> RefreshShow()
        {
            var vm = new List<RateToShowViewModel>();
            var shows = _coachshowdata.GetAllUnRatedByCoachShow(User.FindFirstValue(ClaimTypes.NameIdentifier));
            foreach (var show in shows)
            {
                vm.Add(new RateToShowViewModel
                {
                    show = show,
                });
            }
            return vm;
        }
        public async Task<IActionResult> Coachdashboard()
        {
            var user = await _usermanager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(user);
        }

        public IActionResult AddRatingToShows()
        {
            return View(RefreshShow());
        }
        [HttpPost]
        public IActionResult AddShowRate(int score, int showid)
        {
            if (score >= 0 && score <= 20 && showid != 0)
            {
                bool add_rate_status = _coachshowdata.AddRate(showid, User.FindFirstValue(ClaimTypes.NameIdentifier), score);
                if (add_rate_status)
                {
                    return RedirectToAction(nameof(Coachdashboard));
                }
                else
                {
                    ViewBag.massage = "مشکلی در افزودن نمره رخ داد";
                    return View("", RefreshShow());
                }
            }
            else
            {
                ViewBag.massage = "مقدار ورودی باید از 0 تا 20 باشد";
                return View("AddRatingToShows", RefreshShow());
            }

        }

        public IActionResult AllShow()
        {
            var vm = new List<AllShowViewModel>();
            var shows = _playershowdata.GetAllShow();
            foreach (var show in shows)
            {
                var coachname = _coachdata.GetCoachNameWithShowId(show.ShowId);
                vm.Add(new AllShowViewModel()
                {
                    Shows = show,
                    Coach = coachname
                });
            }
            return View(vm);
        }

        public IActionResult EditCoach()
        {
            var vm = new EditCoachPersonalViewModel();
            var coach = _usermanager.Users.Where(e => e.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).First();
            vm.PhoneNumber = coach.PhoneNumber;
            vm.Name = coach.Name;
            vm.EmailAddress = coach.Email;
            vm.LastName = coach.LastName;
            return View(vm);
        }
        [HttpPost]
        public IActionResult EditCoach(EditCoachPersonalViewModel newcoach)
        {
            if (ModelState.IsValid)
            {
                var userid = _usermanager.Users.Where(e => e.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(e => e.Id).First();
                var user = new RmUserIdentity()
                {
                    Name = newcoach.Name,
                    LastName = newcoach.LastName,
                    Email = newcoach.EmailAddress,
                    PhoneNumber = newcoach.PhoneNumber,
                };
                bool editstatus = _coachdata.EditCoach(userid, user);
                if (editstatus)
                {
                    return RedirectToAction(nameof(Coachdashboard));
                }
                else
                {
                    ModelState.AddModelError("", "خطایی در ویرایش رخ داد");
                    return View(newcoach);
                }
            }
            else
            {
                return View(newcoach);
            }
        }

        public IActionResult ManageTeam()
        {
            return View(_coachteamdata.GetTeamsByCoachId(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        public async Task <IActionResult> ManagespecificTeam(int teamid)
        {
            var vm = new ManagespecificTeamViewModel();
            vm.Team = _coachteamdata.GetTeamById(teamid);
            var existUser = _playerdata.GetPlayerByTeam(teamid);
            var allplayer =await _playerdata.GetAllPlayerWithoutTeam();
            List<RmUserIdentity> rm = new List<RmUserIdentity>();
            vm.ExistPlayer = existUser;
            vm.NewPlayers = (List<RmUserIdentity>)allplayer;

            var coach = _usermanager.Users.Where(e => e.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(e => e.Name + " " + e.LastName).FirstOrDefault();
            ViewBag.Coachname = coach;
            ViewBag.PlayerCount=existUser.Count();

            return View(vm);
        }

        public IActionResult AddPlayerToTeam(int teamid,string playerid)
        {
            if(teamid!=0 && playerid!=null)
            {
               bool addstatus= _playerdata.AddPlayerToTeam(playerid, teamid);
                if(addstatus)
                {
                   
                    return RedirectToAction(nameof(ManagespecificTeam), new { teamid = teamid });
                }
                else
                {
                    ViewBag.massage = "خطایی در افزودن رخ داد";
                    return View();
                }
                

            }
            return NotFound();
        }

        public IActionResult deleteFromTeam(int teamid,string Playerid)
        {
            if(teamid!=0 && Playerid!=null)
            {
               bool deletestatus= _playerdata.DeletePlayerToTeam(Playerid, teamid);
                if(deletestatus)
                {
                    return RedirectToAction(nameof(ManagespecificTeam),new {teamid=teamid});

                }
                else
                {
                    ViewBag.massage = "خطایی در حذف رخ داد";
                    return View();
                }
            }
            else
            {
                return NotFound();
            }
        }

    }

}
