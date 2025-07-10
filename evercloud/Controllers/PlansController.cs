using evercloud.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace evercloud.Controllers
{
    public class PlansController : Controller
    {
        public IActionResult Entry()
        {
            var plans = LoadPlans();
            var entryPlan = plans.FirstOrDefault(p => string.Equals(p.Title, "Entry", StringComparison.OrdinalIgnoreCase));

            if (entryPlan == null)
            {
                return NotFound("Entry plan not found.");
            }

            return View(entryPlan);
        }

        public IActionResult Premium()
        {
            var plans = LoadPlans();
            var premiumPlan = plans.FirstOrDefault(p => string.Equals(p.Title, "Premium", StringComparison.OrdinalIgnoreCase));

            if (premiumPlan == null)
            {
                return NotFound("Premium plan not found.");
            }

            return View(premiumPlan);
        }

        public IActionResult Pro()
        {
            var plans = LoadPlans();
            var proPlan = plans.FirstOrDefault(p => string.Equals(p.Title, "Pro", StringComparison.OrdinalIgnoreCase));

            if (proPlan == null)
            {
                return NotFound("Pro plan not found.");
            }

            return View(proPlan);
        }

        private static List<Plan> LoadPlans()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data/plans.json");
            var json = System.IO.File.ReadAllText(jsonPath);
            var plans = System.Text.Json.JsonSerializer.Deserialize<List<Plan>>(json);
            return plans ?? [];
        }
    }
}
