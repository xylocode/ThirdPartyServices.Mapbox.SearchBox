using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class Feature
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// An object describing the spatial geometry of the returned feature.
        /// </summary>
        [JsonPropertyName("geometry")]
        public FeatureGeometry Geometry { get; set; }

        /// <summary>
        /// The specific properties associated with the returned feature.
        /// </summary>
        [JsonPropertyName("properties")]
        public FeatureProperties Properties { get; set; }
    }


}