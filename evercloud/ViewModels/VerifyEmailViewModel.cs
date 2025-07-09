using System.ComponentModel.DataAnnotations;

namespace evercloud.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public required string Email { get; set; }
    }
}