using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;

namespace evercloud.Service.Services
{
    public class CheckoutService(ICheckoutRepository checkoutRepository) : ICheckoutService
    {
        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await checkoutRepository.GetAllPurchasesAsync();
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await checkoutRepository.AddPurchaseAsync(purchase);
        }

        public async Task DeletePurchaseAsync(int id)
        {
            await checkoutRepository.DeletePurchaseAsync(id);
        }
    }
}
