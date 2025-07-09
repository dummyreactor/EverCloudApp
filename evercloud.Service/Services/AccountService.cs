//using evercloud.DataAccess.Repositories;
//using evercloud.Domain.Models;
//using evercloud.Service.Interfaces;
//using System.Threading.Tasks;

//namespace evercloud.Service.Services
//{
//    public class AccountService : IAccountService
//    {
//        private readonly IAccountRepository _accountRepository;

//        public AccountService(IAccountRepository accountRepository)
//        {
//            _accountRepository = accountRepository;
//        }

//        public async Task<Users?> FindByEmailAsync(string email)
//        {
//            return await _accountRepository.FindByEmailAsync(email);
//        }

//        public async Task<Users?> FindByUsernameAsync(string username)
//        {
//            return await _accountRepository.FindByUsernameAsync(username);
//        }

//        public async Task<bool> RegisterUserAsync(Users user, string password)
//        {
//            return await _accountRepository.CreateUserAsync(user, password);
//        }

//        public async Task<bool> ResetPasswordAsync(Users user, string newPassword)
//        {
//            bool removed = await _accountRepository.RemovePasswordAsync(user);
//            if (!removed) return false;

//            return await _accountRepository.AddPasswordAsync(user, newPassword);
//        }

//        public async Task<bool> DeleteAccountAsync(Users user)
//        {
//            return await _accountRepository.DeleteUserAsync(user);
//        }
//    }
//}

using evercloud.DataAccess.Repositories;
using evercloud.Service.Interfaces;

namespace evercloud.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Users? FindByEmail(string email)
        {
            return _accountRepository.FindByEmailAsync(email).Result;
        }

        public Users? FindByUsername(string username)
        {
            return _accountRepository.FindByUsernameAsync(username).Result;
        }

        public bool RegisterUser(Users user, string password)
        {
            return _accountRepository.CreateUserAsync(user, password).Result;
        }

        public bool ResetPassword(Users user, string newPassword)
        {
            bool removed = _accountRepository.RemovePasswordAsync(user).Result;
            if (!removed) return false;

            return _accountRepository.AddPasswordAsync(user, newPassword).Result;
        }

        public bool DeleteAccount(Users user)
        {
            return _accountRepository.DeleteUserAsync(user).Result;
        }
    }
}
