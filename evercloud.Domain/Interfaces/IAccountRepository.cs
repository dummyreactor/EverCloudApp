﻿using evercloud.Domain.Models;
using System.Threading.Tasks;

//namespace evercloud.DataAccess.Repositories
namespace evercloud.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Users?> FindByEmailAsync(string email);
        Task<Users?> FindByUsernameAsync(string username);
        Task<bool> CreateUserAsync(Users user, string password);
        Task<bool> RemovePasswordAsync(Users user);
        Task<bool> AddPasswordAsync(Users user, string newPassword);
        Task<bool> DeleteUserAsync(Users user);
    }
}
