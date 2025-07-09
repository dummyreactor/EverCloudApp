using evercloud.Domain.Models;

namespace evercloud.Service.Interfaces
{
    public interface IPlanService
    {
        Task<List<Plan>> GetAllPlansAsync();
    }
}
