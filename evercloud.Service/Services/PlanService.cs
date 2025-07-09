using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;
using System.Text.Json;

namespace evercloud.Service.Services
{
    public class PlanService : IPlanService
    {
        // Reusable serializer options
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<Plan>> GetAllPlansAsync()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "plans.json");

            if (!File.Exists(path))
                return [];

            var json = await File.ReadAllTextAsync(path);
            var plans = JsonSerializer.Deserialize<List<Plan>>(json, _jsonOptions);

            return plans ?? [];
        }
    }
}
