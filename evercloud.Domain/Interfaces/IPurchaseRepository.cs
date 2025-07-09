using evercloud.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace evercloud.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetAllAsync();
        Task<Purchase?> GetByIdAsync(int id);
        Task<IEnumerable<Purchase>> GetByUserIdAsync(string userId);
        Task AddAsync(Purchase purchase);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
