using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;

namespace evercloud.Service.Services
{
    public class CheckoutService(ICheckoutRepository checkoutRepository) : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository = checkoutRepository;

        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await _checkoutRepository.GetAllPurchasesAsync();
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _checkoutRepository.AddPurchaseAsync(purchase);
        }

        public async Task DeletePurchaseAsync(int id)
        {
            await _checkoutRepository.DeletePurchaseAsync(id);
        }
    }
}
