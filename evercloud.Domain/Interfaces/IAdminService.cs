using evercloud.Domain.Models;

//namespace evercloud.Service.Interfaces
namespace evercloud.Domain.Interfaces
{
    public interface IAdminService
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<List<Plan>> LoadPlansAsync();
        Task<bool> UpdatePlansAsync(List<Plan> updatedPlans);
    }
}
