using evercloud.Domain.Models;
using evercloud.Domain.Interfaces;
using evercloud.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace evercloud.DataAccess.Repositories
{
    public class CheckoutRepository(AppDbContext context) : ICheckoutRepository
    {
        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await context.Purchases.ToListAsync();
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            context.Purchases.Add(purchase);
            await context.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int id)
        {
            var purchase = await context.Purchases.FindAsync(id);
            if (purchase != null)
            {
                context.Purchases.Remove(purchase);
                await context.SaveChangesAsync();
            }
        }
    }
}
