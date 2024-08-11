using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private Race_management.Utility.Email_Sender.IEmailSender _emailsender;
        public ShowManagement(IAdminShowData adminShowData, UserManager<RmUserIdentity> userManager, IAdminPlayerData adminPlayer, Race_management.Utility.Email_Sender.IEmailSender emailSender)
        {
            _adminShowData = adminShowData;
            _usermanager = userManager;
            _playerdata = adminPlayer;
            _emailsender = emailSender;
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
                    var allcoach = await _usermanager.GetUsersInRoleAsync("Coach");

                    var text = "<!DOCTYPE html>\r\n<html>\r\n<body>\r\n    <header style=\"width: 100%; background-color: orange; color:white;text-align: center; font-size: 200%;\">مسابقات\r\n    </header>\r\n    <div style=\"text-align: center;\">\r\n        <p>خوش آمدید لطفا از طریق لینک زیر ایمیل خود را تایید کنید.</p>\r\n        <p>اجرای جدیدی اضافه شد لطفا در اسرع وقت نسبت به درج نمره اقدام نمایید با تشکر.</p>\r\n    </div>\r\n</body>\r\n</html>";
                    foreach (var coach in allcoach)
                    {
                        await _emailsender.Send_Email(coach.Email, text, "اجرای جدید", true);
                    }
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

        public async Task<IActionResult> SearchShow(string id, string title, string DateFrom, string DateTo, string Player, string Orderby)
        {
            List<ShowManagementViewModel> vm = new List<ShowManagementViewModel>();
            DateTime? datef = new DateTime?();
            DateTime? dateto = new DateTime?();

            try
            {
                if (DateFrom != null)
                {
                    var date = DateTime.Parse(DateFrom);
                    datef = DateCalculator.Tomiladi(date);
                }
                if (DateTo != null)
                {

                    var date = DateTime.Parse(DateTo);
                    dateto = DateCalculator.Tomiladi(date);
                }
            }
            catch
            {
                ViewBag.massage = "فرمت تاریخ درست نیست";

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
                return View("ManageShow", vm);
            }
            var searchItem = _adminShowData.SearchShow(Convert.ToInt32(id), title, datef, dateto, Player, Orderby);
            foreach (var show in searchItem)
            {
                vm.Add(new ShowManagementViewModel()
                {
                    title = show.ShowTitle,
                    Score = show.AverageScore,
                    date = DateCalculator.DateToShamshi(show.ShowDate),
                    Id = show.ShowId,
                    PlayerNames = new Player_name_id_viewmodel()
                    {
                        id = show.ShowplayerId,
                        name = show.ShowPlayer.Name + " " + show.ShowPlayer.LastName,
                    }
                });
            }
            return View("ManageShow", vm);
        }


    }
}
