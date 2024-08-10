using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Data.ICoachShowData;
using Race_management.Models;
using Race_management.Utility;
using Race_management.ViewModel.CoachDashboard;
using System.Security.Claims;

namespace Race_management.Controllers
{
    [Authorize(Roles = "Coach")]
    public class CoachDashboard : Controller
    {
        private UserManager<RmUserIdentity> _usermanager;
        private ICoachShowData _coachshowdata;
        public CoachDashboard(UserManager<RmUserIdentity> usermanager, ICoachShowData coachShowData)
        {
            _usermanager = usermanager;
            _coachshowdata = coachShowData;
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
            if (score >= 0 && score <= 20 && showid!=0)
            {
                bool add_rate_status=_coachshowdata.AddRate(showid,User.FindFirstValue(ClaimTypes.NameIdentifier),score);
                if (add_rate_status)
                {
                    return RedirectToAction(nameof(Coachdashboard));
                }
                else
                {
                    ViewBag.massage = "مشکلی در افزودن نمره رخ داد";
                    return View("",RefreshShow());
                }
            }
            else
            {
                ViewBag.massage = "مقدار ورودی باید از 0 تا 20 باشد";
                return View("AddRatingToShows", RefreshShow());
            }

        }
    }
}
