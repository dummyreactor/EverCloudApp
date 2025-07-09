using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;
using evercloud.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace evercloud.DataAccess.Repositories
{
    public class CheckoutRepository(AppDbContext context) : ICheckoutRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
