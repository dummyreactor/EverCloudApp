using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;

namespace evercloud.Service.Services
{
    public class PurchaseService(IPurchaseRepository purchaseRepository) : IPurchaseService
    {
        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            var purchases = await purchaseRepository.GetAllAsync();
            return [.. purchases]; // Ensures return type matches
        }

        public async Task<Purchase?> GetPurchaseByIdAsync(int id)
        {
            return await purchaseRepository.GetByIdAsync(id);
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await purchaseRepository.AddAsync(purchase);
            await purchaseRepository.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int id)
        {
            await purchaseRepository.DeleteAsync(id);
            await purchaseRepository.SaveChangesAsync();
        }

        public async Task<bool> HasActivePurchaseAsync(string userId)
        {
            var purchases = await purchaseRepository.GetAllAsync();
            return purchases.Any(p => p.UserId == userId);
        }

        public async Task<List<Purchase>> GetUserPurchasesAsync(string userId)
        {
            var purchases = await purchaseRepository.GetAllAsync();
            return [.. purchases
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.PurchaseDate)];
        }

        public async Task<bool> CancelPurchaseByUserIdAsync(string userId)
        {
            var purchases = await purchaseRepository.GetAllAsync();
            var purchase = purchases.FirstOrDefault(p => p.UserId == userId);

            if (purchase == null)
                return false;

            await purchaseRepository.DeleteAsync(purchase.Id);
            await purchaseRepository.SaveChangesAsync();
            return true;
        }

    }
}
