using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class Address : IdName
    {
        [JsonPropertyName("address_number")]
        public string AddressNumber { get; set; }

        [JsonPropertyName("street_name")]
        public string StreetName { get; set; }
    }
}