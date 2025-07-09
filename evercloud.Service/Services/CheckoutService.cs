using evercloud.Domain.Models;
using evercloud.Domain.Repositories;
using evercloud.Service.Interfaces;

namespace evercloud.Service.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutService(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }

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
