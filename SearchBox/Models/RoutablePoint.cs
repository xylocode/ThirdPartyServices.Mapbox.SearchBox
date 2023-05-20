using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class RoutablePoint
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }
    }
}