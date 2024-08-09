using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Race_management.Areas.Admin.Data.AdminTeamData;
using Race_management.Areas.Admin.Data.IAdminCoachData;
using Race_management.Areas.Admin.ViewModel.CoachManagement;

namespace Race_management.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class CoachManagement : Controller
    {
        private IAdminCoachData _admincoachdata;
        private IAdminTeamData _adminteamdata;

        public CoachManagement(IAdminCoachData coachdata,IAdminTeamData Teamdata)
        {
            _admincoachdata = coachdata;
            _adminteamdata = Teamdata;
        }
        public async Task <IActionResult> Coachmanage()
        {
            List<CoachManageViewModel> vm = new List<CoachManageViewModel>();
            var coachs =await _admincoachdata.GetAllCoach();
            foreach(var coach in coachs)
            {
                var teamsName = _adminteamdata.GetTeamByCoach(coach.Id);
                vm.Add(new CoachManageViewModel
                {
                    CoachName = coach.Name,
                    CoachEmail = coach.Email,
                    CoachFamily = coach.LastName,
                    CoachPhone = coach.PhoneNumber,
                    CoachTeamNames = teamsName,
                });

            }           
            return View(vm);
        }
    }
}
