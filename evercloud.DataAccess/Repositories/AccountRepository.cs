using Microsoft.AspNetCore.Identity;
using evercloud.Domain.Interfaces;

namespace evercloud.DataAccess.Repositories
{
    public class AccountRepository(UserManager<Users> userManager) : IAccountRepository
    {
        public async Task<Users?> FindByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<Users?> FindByUsernameAsync(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<bool> CreateUserAsync(Users user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> RemovePasswordAsync(Users user)
        {
            var result = await userManager.RemovePasswordAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> AddPasswordAsync(Users user, string newPassword)
        {
            var result = await userManager.AddPasswordAsync(user, newPassword);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(Users user)
        {
            var result = await userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
