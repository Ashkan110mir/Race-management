using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Areas.Admin.Data.AdminPlayerData;
using Race_management.Areas.Admin.Data.AdminShowData;
using Race_management.Areas.Admin.ViewModel.ShowManagement;
using Race_management.Models;
using Race_management.Utility;
using System.Runtime.Intrinsics.X86;

namespace Race_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class ShowManagement : Controller
    {
        private IAdminShowData _adminShowData;
        private UserManager<RmUserIdentity> _usermanager;
        private IAdminPlayerData _playerdata;
        public ShowManagement(IAdminShowData adminShowData, UserManager<RmUserIdentity> userManager, IAdminPlayerData adminPlayer)
        {
            _adminShowData = adminShowData;
            _usermanager = userManager;
            _playerdata = adminPlayer;
        }
        private async Task<List<Player_name_id_viewmodel>> GetPlayer()
        {
            var users = await _playerdata.GetAllPlayer();
            var Players = new List<Player_name_id_viewmodel>();
            foreach (var player in users)
            {
                var playernameID = new Player_name_id_viewmodel()
                {
                    id = player.Id,
                    name = player.Name + " " + player.LastName,
                };
                Players.Add(playernameID);
            }
            return Players;
        }

        public async Task<IActionResult> ManageShow()
        {
            List<ShowManagementViewModel> vm = new List<ShowManagementViewModel>();

            var shows = _adminShowData.GetAllShow();
            foreach (var show in shows)
            {
                var user = await _usermanager.FindByIdAsync(show.ShowplayerId);
                Player_name_id_viewmodel name_id = new Player_name_id_viewmodel()
                {
                    id = user.Id,
                    name = user.Name + " " + user.LastName
                };
                vm.Add(new ShowManagementViewModel()
                {
                    title = show.ShowTitle,
                    Id = show.ShowId,
                    Score = show.AverageScore,
                    PlayerNames = name_id,
                    date = DateCalculator.DateToShamshi(show.ShowDate)
                });

            }
            return View(vm);
        }


        public async Task<IActionResult> AddShow()
        {
            var users = await _playerdata.GetAllPlayer();
            AddShowViewModel vm = new AddShowViewModel();
            ViewBag.isadd = 1;
            vm.Players = await GetPlayer();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddShow(AddShowViewModel newshow)
        {
            if (ModelState.IsValid)
            {
                DateTime showdate;
                DateTime miladidate;
                try
                {
                    showdate = DateTime.Parse(newshow.DateTime);
                    miladidate = DateCalculator.Tomiladi(showdate);
                }
                catch
                {
                    ModelState.AddModelError("", "فرمت تاریخ درست نیست");
                    newshow.Players = await GetPlayer();
                    return View(newshow);
                }

                var show = new Show()
                {
                    ShowTitle = newshow.Title,
                    ShowDate = miladidate,
                    ShowplayerId = newshow.SelectedPlayerID,
                    AverageScore = -1,
                    Isactive = true,
                };
                bool addshowstatus = _adminShowData.AddShow(show);
                if (addshowstatus)
                {
                    return RedirectToAction(nameof(ManageShow));
                }
                else
                {
                    newshow.Players = await GetPlayer();
                    ModelState.AddModelError("", "خطایی در افزودن رخ داد");
                    return View(newshow);
                }
            }
            else
            {
                newshow.Players = await GetPlayer();
                return View(newshow);
            }

        }


        public IActionResult DeleteShow(int Showid)
        {
            if (Showid == 0)
            {
                return NotFound();
            }
            bool deletestatus = _adminShowData.RemoveShow(Showid);
            if (deletestatus)
            {
                return RedirectToAction(nameof(ManageShow));
            }
            else
            {
                ViewBag.massage = "خطایی در حذف رخ داد";
                return View();
            }

        }


        public async Task<IActionResult> EditShow(int Showid)
        {
            var show = _adminShowData.GetShowById(Showid);
            if (show == null)
            {
                return NotFound();
            }
            ViewBag.isadd = 0;
            ViewBag.Id = show.ShowId;
            AddShowViewModel vm = new AddShowViewModel()
            {
                Title = show.ShowTitle,
                DateTime = DateCalculator.DateToShamshi(show.ShowDate),
                SelectedPlayerID = show.ShowplayerId,
            };
            vm.Players = await GetPlayer();
            return View("AddShow", vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditShow(AddShowViewModel Editshow, int id)
        {
            if (ModelState.IsValid)
            {
                DateTime date;
                DateTime miladi;
                try
                {
                    date = DateTime.Parse(Editshow.DateTime);
                    miladi = DateCalculator.Tomiladi(date);
                }
                catch
                {
                    ModelState.AddModelError("", "فرمت تاریخ درست نیست");
                    Editshow.Players = await GetPlayer();
                    return View("AddShow", Editshow);
                }
                var newshow = new Show()
                {
                    ShowId = id,
                    ShowDate = miladi,
                    ShowplayerId = Editshow.SelectedPlayerID,
                    ShowTitle = Editshow.Title,
                };
                bool editstatus = _adminShowData.EditShow(newshow);
                if (editstatus)
                {
                    return RedirectToAction(nameof(ManageShow));
                }
                else
                {
                    ModelState.AddModelError("", "خطایی در افزودن رخ داد.");
                    Editshow.Players = await GetPlayer();
                    return View("AddShow", Editshow);
                }
            }
            else
            {
                Editshow.Players = await GetPlayer();
                return View("AddShow", Editshow);
            }
           
        }


    }
}
