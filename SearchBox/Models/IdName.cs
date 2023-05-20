using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class IdName
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

}