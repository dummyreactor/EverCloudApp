using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace evercloud.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<Users> _userManager;
        public DashboardController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.FullName = user.FullName;
            }
            return View();
        }
    }
}
