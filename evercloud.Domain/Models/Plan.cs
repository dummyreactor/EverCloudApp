using System.Text.Json.Serialization;

namespace evercloud.Domain.Models
{
    public class Plan
    {
        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("priceMain")]
        public required string PriceMain { get; set; }

        [JsonPropertyName("priceSub")]
        public required string PriceSub { get; set; }

        [JsonPropertyName("badge")]
        public required string Badge { get; set; }

        [JsonPropertyName("badgeClass")]
        public required string BadgeClass { get; set; }

        [JsonPropertyName("headerClass")]
        public required string HeaderClass { get; set; }

        [JsonPropertyName("buttonClass")]
        public required string ButtonClass { get; set; }

        [JsonPropertyName("buttonText")]
        public required string ButtonText { get; set; }

        [JsonPropertyName("features")]
        public required List<string> Features { get; set; }
    }
}
