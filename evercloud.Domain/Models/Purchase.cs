using System.ComponentModel.DataAnnotations;

namespace evercloud.Domain.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty; 

        [Required]
        public string Plan { get; set; } = string.Empty;

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public Users User { get; set; } = null!;
    }
}
