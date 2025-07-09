using evercloud.Domain.Models;
using evercloud.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace evercloud.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<Users> _userManager;
        private readonly string _jsonPath;

        public AdminService(UserManager<Users> userManager, string jsonPath)
        {
            _userManager = userManager;
            _jsonPath = jsonPath;
        }

        public Task<List<Users>> GetAllUsersAsync()
        {
            return Task.FromResult(_userManager.Users.ToList());
        }

        public async Task<List<Plan>> LoadPlansAsync()
        {
            if (!File.Exists(_jsonPath))
                return new List<Plan>();

            var json = await File.ReadAllTextAsync(_jsonPath);
            return JsonSerializer.Deserialize<List<Plan>>(json) ?? new List<Plan>();
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

            var json = JsonSerializer.Serialize(existingPlans, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(_jsonPath, json);
            return true;
        }
    }
}
