using evercloud.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using evercloud.Domain.Interfaces;

namespace evercloud.DataAccess.Repositories
{
    public class AccountRepository(UserManager<Users> userManager) : IAccountRepository
    {
        private readonly UserManager<Users> _userManager = userManager;

        public async Task<Users?> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<Users?> FindByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> CreateUserAsync(Users user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> RemovePasswordAsync(Users user)
        {
            var result = await _userManager.RemovePasswordAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> AddPasswordAsync(Users user, string newPassword)
        {
            var result = await _userManager.AddPasswordAsync(user, newPassword);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(Users user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
