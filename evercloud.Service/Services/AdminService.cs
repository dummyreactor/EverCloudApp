using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace evercloud.Service.Services
{
    public class AdminService(UserManager<Users> userManager, string jsonPath) : IAdminService
    {
        private readonly UserManager<Users> _userManager = userManager;
        private readonly string _jsonPath = jsonPath;

        // ✅ Cached, shared options object
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true
        };

        public Task<List<Users>> GetAllUsersAsync()
        {
            return Task.FromResult(_userManager.Users.ToList());
        }

        public async Task<List<Plan>> LoadPlansAsync()
        {
            if (!File.Exists(_jsonPath))
                return [];

            var json = await File.ReadAllTextAsync(_jsonPath);
            return JsonSerializer.Deserialize<List<Plan>>(json, _jsonOptions) ?? [];
        }

        public async Task<bool> UpdatePlansAsync(List<Plan> updatedPlans)
        {
            var existingPlans = await LoadPlansAsync();

            foreach (var existing in existingPlans)
            {
                var updated = updatedPlans.FirstOrDefault(p => p.Title == existing.Title);
                if (updated != null)
                {
                    existing.PriceMain = updated.PriceMain;
                    existing.Badge = updated.Badge;
                }
            }

            var json = JsonSerializer.Serialize(existingPlans, _jsonOptions);
            await File.WriteAllTextAsync(_jsonPath, json);
            return true;
        }
    }
}
