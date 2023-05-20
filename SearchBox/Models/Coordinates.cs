using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class Coordinates
    {
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }


        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }


        [JsonPropertyName("accuracy")]
        public string Accuracy { get; set; }


        [JsonPropertyName("routable_points")]
        public List<RoutablePoint> RoutablePoints { get; set; }
    }
}