using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class SuggestionResult
    {
        [JsonPropertyName("suggestions")]
        public List<Suggestion> Suggestions { get; set; }

        [JsonPropertyName("attribution")]
        public string Attribution { get; set; }
    }
}
