using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evercloud.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(IAdminService adminService, IPurchaseService purchaseService) : Controller
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> UsersList()
        {
            var users = await adminService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Purchases()
        {
            var purchases = await purchaseService.GetAllPurchasesAsync();
            purchases = [.. purchases.OrderByDescending(p => p.PurchaseDate)];
            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> ManagePlans()
        {
            var plans = await adminService.LoadPlansAsync();
            return View(plans);
        }

        [HttpPost]
        public async Task<IActionResult> ManagePlans(List<Plan> updatedPlans)
        {
            var success = await adminService.UpdatePlansAsync(updatedPlans);
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
