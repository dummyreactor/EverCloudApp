using evercloud.Domain.Models;
using evercloud.Domain.Repositories;
using evercloud.Service.Interfaces;

namespace evercloud.Service.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return purchases.ToList(); // Ensures return type matches
        }

        public async Task<Purchase?> GetPurchaseByIdAsync(int id)
        {
            return await _purchaseRepository.GetByIdAsync(id);
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _purchaseRepository.AddAsync(purchase);
            await _purchaseRepository.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int id)
        {
            await _purchaseRepository.DeleteAsync(id);
            await _purchaseRepository.SaveChangesAsync();
        }

        public async Task<bool> HasActivePurchaseAsync(string userId)
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return purchases.Any(p => p.UserId == userId);
        }

        public async Task<List<Purchase>> GetUserPurchasesAsync(string userId)
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return purchases
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.PurchaseDate)
                .ToList();
        }

        public async Task<bool> CancelPurchaseByUserIdAsync(string userId)
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            var purchase = purchases.FirstOrDefault(p => p.UserId == userId);

            if (purchase == null)
                return false;

            await _purchaseRepository.DeleteAsync(purchase.Id);
            await _purchaseRepository.SaveChangesAsync();
            return true;
        }

    }
}
