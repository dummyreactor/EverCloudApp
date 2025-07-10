using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;

namespace evercloud.Controllers
{
    [Authorize]
    public class CheckoutController(IPurchaseService purchaseService, UserManager<Users> userManager) : Controller
    {
        public IActionResult Index(string plan)
        {
            if (string.IsNullOrEmpty(plan))
                return RedirectToAction("Index", "Home");

            ViewData["Plan"] = plan;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(string plan)
        {
            if (string.IsNullOrEmpty(plan))
                return RedirectToAction("Index", "Home");

            var user = await userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var allPurchases = await purchaseService.GetAllPurchasesAsync();
            var existingPurchase = allPurchases.FirstOrDefault(p => p.UserId == user.Id);

            if (existingPurchase != null)
            {
                TempData["Error"] = "You already have an active subscription.";
                return RedirectToAction("Dashboard");
            }

            var purchase = new Purchase
            {
                UserId = user.Id,
                Plan = plan
            };

            await purchaseService.AddPurchaseAsync(purchase);


            TempData["Success"] = $"✅ You have successfully subscribed to the {plan} plan!";
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            ViewBag.Message = TempData["Success"];
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) 
                return Unauthorized();
            
            ViewBag.FullName = user.FullName;

            var allPurchases = await purchaseService.GetAllPurchasesAsync();
            var purchases = allPurchases
                .Where(p => p.UserId == user.Id)
                .OrderByDescending(p => p.PurchaseDate)
                .ToList();


            ViewBag.Error = TempData["Error"];
            return View(purchases);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Cancel()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var allPurchases = await purchaseService.GetAllPurchasesAsync();
            var purchase = allPurchases.FirstOrDefault(p => p.UserId == user.Id);

            if (purchase == null)
            {
                TempData["Error"] = "No active plan to cancel.";
                return RedirectToAction("Dashboard");
            }

            await purchaseService.DeletePurchaseAsync(purchase.Id);


            TempData["Message"] = "❌ Your plan has been canceled.";
            return RedirectToAction("Dashboard");
        }
    }
}
