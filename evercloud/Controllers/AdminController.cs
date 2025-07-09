using evercloud.Domain.Models;
using evercloud.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evercloud.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IPurchaseService _purchaseService;

        public AdminController(IAdminService adminService, IPurchaseService purchaseService)
        {
            _adminService = adminService;
            _purchaseService = purchaseService;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> UsersList()
        {
            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Purchases()
        {
            var purchases = await _purchaseService.GetAllPurchasesAsync();
            purchases = purchases.OrderByDescending(p => p.PurchaseDate).ToList();
            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> ManagePlans()
        {
            var plans = await _adminService.LoadPlansAsync();
            return View(plans);
        }

        [HttpPost]
        public async Task<IActionResult> ManagePlans(List<Plan> updatedPlans)
        {
            var success = await _adminService.UpdatePlansAsync(updatedPlans);
            if (success)
            {
                TempData["Message"] = "Plans updated successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to update plans.";
            }

            return RedirectToAction("ManagePlans");
        }
    }
}
