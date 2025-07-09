using evercloud.Domain.Models;

namespace evercloud.Service.Interfaces
{
    public interface ICheckoutService
    {
        Task<List<Purchase>> GetAllPurchasesAsync();
        Task AddPurchaseAsync(Purchase purchase);
        Task DeletePurchaseAsync(int id);
    }
}
