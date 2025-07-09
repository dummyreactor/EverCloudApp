using evercloud.Domain.Models;

namespace evercloud.Service.Interfaces
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetAllPurchasesAsync();
        Task<Purchase?> GetPurchaseByIdAsync(int id);
        Task AddPurchaseAsync(Purchase purchase);
        Task DeletePurchaseAsync(int id);

        //Checkout Controller
        Task<bool> HasActivePurchaseAsync(string userId);
        Task<List<Purchase>> GetUserPurchasesAsync(string userId);
        Task<bool> CancelPurchaseByUserIdAsync(string userId);

    }
}
