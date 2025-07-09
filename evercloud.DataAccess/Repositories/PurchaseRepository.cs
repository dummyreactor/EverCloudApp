using evercloud.DataAccess.Data;
using evercloud.Domain.Models;
using Microsoft.EntityFrameworkCore;
using evercloud.Domain.Interfaces;  

namespace evercloud.DataAccess.Repositories
{
    public class PurchaseRepository(AppDbContext context) : IPurchaseRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await _context.Purchases
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Purchase?> GetByIdAsync(int id)
        {
            return await _context.Purchases
                .Include(p => p.User)
                .Include(p => p.Plan)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Purchase>> GetByUserIdAsync(string userId)
        {
            return await _context.Purchases
                .Include(p => p.Plan)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
        }

        public async Task DeleteAsync(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
