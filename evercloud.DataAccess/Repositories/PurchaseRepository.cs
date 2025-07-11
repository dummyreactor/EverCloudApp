using evercloud.DataAccess.Data;
using evercloud.Domain.Models;
using Microsoft.EntityFrameworkCore;
using evercloud.Domain.Interfaces;  

namespace evercloud.DataAccess.Repositories
{
    public class PurchaseRepository(AppDbContext context) : IPurchaseRepository
    {
        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await context.Purchases
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Purchase?> GetByIdAsync(int id)
        {
            return await context.Purchases
                .Include(p => p.User)
                .Include(p => p.Plan)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Purchase>> GetByUserIdAsync(string userId)
        {
            return await context.Purchases
                .Include(p => p.Plan)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Purchase purchase)
        {
            await context.Purchases.AddAsync(purchase);
        }

        public async Task DeleteAsync(int id)
        {
            var purchase = await context.Purchases.FindAsync(id);
            if (purchase != null)
            {
                context.Purchases.Remove(purchase);
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
