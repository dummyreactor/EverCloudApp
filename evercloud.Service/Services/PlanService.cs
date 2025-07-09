using evercloud.Domain.Models;
using evercloud.Service.Interfaces;
using System.Text.Json;

namespace evercloud.Service.Services
{
    public class PlanService : IPlanService
    {
        public async Task<List<Plan>> GetAllPlansAsync()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "plans.json");

            if (!File.Exists(path))
                return new List<Plan>();

            var json = await File.ReadAllTextAsync(path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var plans = JsonSerializer.Deserialize<List<Plan>>(json, options);

            return plans ?? new List<Plan>();
        }
    }
}
