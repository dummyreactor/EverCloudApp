namespace evercloud.Domain.Interfaces
{
    public interface IDomainService
    {
        Task<bool> IsDomainAvailableAsync(string domain);
    }
}
