using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class RetrieveResult
    {
        /// <summary>
        /// This will always be "FeatureCollection".
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The returned feature objects.
        /// </summary>
        [JsonPropertyName("features")]
        public List<Feature> Features { get; set; }


        /// <summary>
        /// The attribution data for results.
        /// </summary>
        [JsonPropertyName("attribution")]
        public string Attribution { get; set; }
    }

}
