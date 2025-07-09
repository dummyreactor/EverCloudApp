using Microsoft.AspNetCore.Mvc;
using evercloud.Service.Interfaces;
using evercloud.Domain.Models;

namespace evercloud.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanService _planService;

        public HomeController(IPlanService planService)
        {
            _planService = planService;
        }

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
