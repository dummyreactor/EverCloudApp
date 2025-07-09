using System.Threading.Tasks;

namespace evercloud.Service.Interfaces
{
    public interface IDomainService
    {
        Task<bool> IsDomainAvailableAsync(string domain);
    }
}
