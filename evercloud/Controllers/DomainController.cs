using Microsoft.AspNetCore.Mvc;
using evercloud.Domain.Interfaces;
using evercloud.ViewModels;

namespace evercloud.Controllers
{
    public class DomainController(IDomainService domainService) : Controller
    {
        private readonly IDomainService _domainService = domainService;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckAvailability(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                return PartialView("_SearchResult", new DomainResultViewModel
                {
                    Domain = string.Empty,
                    IsAvailable = false
                });
            }

            bool isAvailable = await _domainService.IsDomainAvailableAsync(domainName);

            var result = new DomainResultViewModel
            {
                Domain = domainName,
                IsAvailable = isAvailable
            };

            return PartialView("_SearchResult", result);
        }
    }
}