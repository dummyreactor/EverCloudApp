using Microsoft.AspNetCore.Mvc;
using evercloud.Domain.Interfaces;

namespace evercloud.Controllers
{
    public class HomeController(IPlanService planService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var plans = await planService.GetAllPlansAsync();
            return View(plans);
        }

        public IActionResult Features()
        {
            return View();
        }
    }
}
