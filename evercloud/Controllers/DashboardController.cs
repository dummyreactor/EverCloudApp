using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace evercloud.Controllers
{
    public class DashboardController(UserManager<Users> userManager) : Controller
    {
        private readonly UserManager<Users> _userManager = userManager;

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
