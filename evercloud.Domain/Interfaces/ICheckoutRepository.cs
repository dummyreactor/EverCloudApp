using evercloud.Domain.Models;

namespace evercloud.Domain.Repositories
{
    public interface ICheckoutRepository
    {
        Task<List<Purchase>> GetAllPurchasesAsync();
        Task AddPurchaseAsync(Purchase purchase);
        Task DeletePurchaseAsync(int id);
    }
}
