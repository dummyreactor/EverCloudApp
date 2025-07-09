//using evercloud.Domain.Models;
//using System.Threading.Tasks;

//namespace evercloud.Service.Interfaces
//{
//    public interface IAccountService
//    {
//        Task<Users?> FindByEmailAsync(string email);
//        Task<Users?> FindByUsernameAsync(string username);
//        Task<bool> RegisterUserAsync(Users user, string password);
//        Task<bool> ResetPasswordAsync(Users user, string newPassword);
//        Task<bool> DeleteAccountAsync(Users user);
//    }
//}

using evercloud.Domain.Models;

namespace evercloud.Service.Interfaces
{
    public interface IAccountService
    {
        Users? FindByEmail(string email);
        Users? FindByUsername(string username);
        bool RegisterUser(Users user, string password);
        bool ResetPassword(Users user, string newPassword);
        bool DeleteAccount(Users user);
    }
}
