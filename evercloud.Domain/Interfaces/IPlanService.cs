using evercloud.Domain.Models;

namespace evercloud.Domain.Interfaces
{
    public interface IPlanService
    {
        Task<List<Plan>> GetAllPlansAsync();
    }
}
