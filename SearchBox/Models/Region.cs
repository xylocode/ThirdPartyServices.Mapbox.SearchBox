using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class Region : IdName
    {

        [JsonPropertyName("region_code")]
        public string RegionCode { get; set; }

        [JsonPropertyName("region_code_full")]
        public string RegionCodeFull { get; set; }
    }
}