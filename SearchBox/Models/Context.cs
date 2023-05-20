using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    /// <summary>
    /// This context has layers that follow the Administrative unit types.
    /// </summary>
    public class Context
    {
        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("region")]
        public Region Region { get; set; }

        [JsonPropertyName("postcode")]
        public IdName PostCode { get; set; }

        [JsonPropertyName("district")]
        public IdName District { get; set; }

        [JsonPropertyName("place")]
        public IdName Place { get; set; }

        [JsonPropertyName("locality")]
        public IdName Locality { get; set; }

        [JsonPropertyName("neighborhood")]
        public IdName Neighborhood { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("street")]
        public IdName Street { get; set; }
    }
}