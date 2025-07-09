using Microsoft.AspNetCore.Mvc;
using evercloud.Domain.Interfaces;
using evercloud.Domain.Models;

namespace evercloud.Controllers
{
    public class HomeController(IPlanService planService) : Controller
    {
        private readonly IPlanService _planService = planService;

        public async Task<IActionResult> Index()
        {
            var plans = await _planService.GetAllPlansAsync();
            return View(plans);
        }

        public IActionResult Features()
        {
            return View();
        }
    }
}
