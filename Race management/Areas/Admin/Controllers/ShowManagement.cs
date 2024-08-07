using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Race_management.Areas.Admin.Data.AdminShowData;
using Race_management.Areas.Admin.ViewModel.ShowManagement;
using Race_management.Models;

namespace Race_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class ShowManagement : Controller
    {
        private IAdminShowData _adminShowData;
        private UserManager<RmUserIdentity> _usermanager;
        public ShowManagement(IAdminShowData adminShowData,UserManager<RmUserIdentity> userManager)
        {
            _adminShowData = adminShowData;
            _usermanager = userManager;
        }
 
        public async Task<IActionResult> ManageShow()
        {
           List<ShowManagementViewModel> vm= new List<ShowManagementViewModel>();
            
            var shows=_adminShowData.GetAllShow();
            foreach (var show in shows)
            {
                var user =await _usermanager.FindByIdAsync(show.ShowplayerId);
                Player_name_id_viewmodel name_id=new Player_name_id_viewmodel()
                {
                    id=user.Id,
                    name=user.Name+" "+user.LastName
                };
                vm.Add(new ShowManagementViewModel()
                {
                    title = show.ShowTitle,
                    Id = show.ShowId,
                    Score = show.AverageScore,
                    PlayerNames = name_id,
                    date = show.ShowDate
                });
       
            }
            return View(vm);
        }
    }
}
