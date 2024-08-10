using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Data.IPlayerCoachData;
using Race_management.Data.PlayerShowData;
using Race_management.Models;
using Race_management.Utility;
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
        public PlayerDashboard(UserManager<RmUserIdentity> usermanager, IPlayerShowData playerShowData,IPlayerCoachData playerCoachData)
        {
            _usermanager = usermanager;
            _playershowdata = playerShowData;
            _playercoachdata = playerCoachData;
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
                        AverageScore=show.AverageScore,    
                    });
                }

            }
            return View(vm);
        }
    }
}
