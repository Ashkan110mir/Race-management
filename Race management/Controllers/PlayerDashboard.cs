using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Race_management.Data.IPlayerCoachData;
using Race_management.Data.PlayerData;
using Race_management.Data.PlayerShowData;
using Race_management.Models;
using Race_management.Utility;
using Race_management.Utility.Email_Sender;
using Race_management.ViewModel.PlayerDashboard;
using System.Security.Claims;

namespace Race_management.Controllers
{
    [Authorize(Roles = "Player")]
    public class PlayerDashboard : Controller
    {
        private UserManager<RmUserIdentity> _usermanager;
        private IPlayerShowData _playershowdata;
        private IPlayerCoachData _playercoachdata;
        private Race_management.Utility.Email_Sender.IEmailSender _emailsender;
        private IPlayerData _playerdata;
        public PlayerDashboard(UserManager<RmUserIdentity> usermanager, IPlayerShowData playerShowData, IPlayerCoachData playerCoachData, Race_management.Utility.Email_Sender.IEmailSender emailsender, IPlayerData playerdata)
        {
            _usermanager = usermanager;
            _playershowdata = playerShowData;
            _playercoachdata = playerCoachData;
            _emailsender = emailsender;
            _playerdata = playerdata;
        }
        public async Task<IActionResult> Playerdashboard()
        {
            PlayerDashboardViewModel vm = new PlayerDashboardViewModel();
            var user = await _usermanager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            vm.Name = user.Name;
            vm.LastName = user.LastName;
            vm.PhoneNumber = user.PhoneNumber;
            vm.Email = user.Email;
            vm.TeamName = _playerdata.PlayerTeamNameById(user.Id);
            var shows = _playershowdata.GetShowbyUserId(user.Id);

            if (shows != null)
            {
                List<PlayerShowForDashboardViewModel> playershows = new List<PlayerShowForDashboardViewModel>();
                foreach (var show in shows)
                {
                    playershows.Add(new PlayerShowForDashboardViewModel()
                    {
                        ShowTitle = show.ShowTitle,
                        ShowDate = DateCalculator.DateToShamshi(show.ShowDate),
                        CoachNames = _playercoachdata.GetCoachNameByShow(show.ShowId),
                        AverageScore = show.AverageScore,
                        
                    });
                }
                vm.PlayerShow = playershows;
            }
            return View(vm);
        }

        public IActionResult EditPersonalInfo()
        {
            var currentUser = _usermanager.Users.Where(e => e.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            var userInfo = new PlayerEditPersonalInfoViewModel()
            {
                Name = currentUser.Name,
                LastName = currentUser.LastName,
                EmailAddress = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber,
            };

            return View(userInfo);
        }
        [HttpPost]
        public async Task<IActionResult> EditPersonalInfo(PlayerEditPersonalInfoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var PreUser = _usermanager.Users.Where(e => e.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                if (PreUser == null)
                {
                    return NotFound();
                }
                else
                {
                    var user = new RmUserIdentity()
                    {
                        Name = vm.Name,
                        LastName = vm.LastName,
                        PhoneNumber = vm.PhoneNumber,

                    };
                    bool edit_status = _playerdata.EditPlayer(User.FindFirstValue(ClaimTypes.NameIdentifier), user);
                    if (edit_status == true)
                    {
                        return RedirectToAction(nameof(Playerdashboard));
                    }
                    else
                    {
                        ModelState.AddModelError("", "خطایی در ویرایش رخ داد");
                        return View(vm);
                    }
                }
            }
            else
            {
                return View(vm);
            }
        }

    }
}
