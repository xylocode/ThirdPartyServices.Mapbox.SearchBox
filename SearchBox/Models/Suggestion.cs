using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models
{
    public class Suggestion
    {
        /// <summary>
        /// The name of the feature.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The preferred name of the feature, if different than name.
        /// </summary>
        [JsonPropertyName("name_preferred")]
        public string NamePreferred { get; set; }

        /// <summary>
        /// The id to use with /retrieve to obtain full feature details.
        /// </summary>
        [JsonPropertyName("mapbox_id")]
        public string MapboxId { get; set; }

        /// <summary>
        /// The type of the result. For POIs, this will be poi.
        /// For categories, this will be category.
        /// For address-type results, the global context hierarchy is used (country, region, postcode, district, place, locality, neighborhood, address).
        /// See the Administrative unit types section for details about these types.
        /// </summary>
        [JsonPropertyName("feature_type")]
        public string FeatureType { get; set; }

        /// <summary>
        /// The address of the result containing the address number and street.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// The full address of the result, which concatenates address and place_formatted.
        /// </summary>
        [JsonPropertyName("full_address")]
        public string FullAddress { get; set; }

        /// <summary>
        /// A formatted string of result context comprised of the place, region, country, and postcode.
        /// </summary>
        [JsonPropertyName("place_formatted")]
        public string PlaceFormatted { get; set; }

        /// <summary>
        /// The context of the feature. This context has layers that follow the Administrative unit types.
        /// </summary>
        [JsonPropertyName("context")]
        public Context Context { get; set; }

        /// <summary>
        /// An IETF language tag indicating the language of the result.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// A string representing an associated Maki icon to use for this result.
        /// </summary>
        [JsonPropertyName("maki")]
        public string MakiIcon { get; set; }

        /// <summary>
        /// An array including the POI categories the result falls into, if it is a POI.
        /// </summary>
        [JsonPropertyName("poi_category")]
        public List<string> PoICategory { get; set; }

        /// <summary>
        /// An array including the canonical POI category IDs the result falls into, if it is a POI.
        /// </summary>
        [JsonPropertyName("poi_category_ids")]
        public List<string> PoICategoryIds { get; set; }

        /// <summary>
        /// The brand name of the result, if it is a POI and is applicable.
        /// </summary>
        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// The canonical brand ID of the result, if it is a POI and is applicable.
        /// </summary>
        [JsonPropertyName("brand_id")]
        public string BrandId { get; set; }

        /// <summary>
        /// An object containing the IDs of the feature found in external databases, with the keys being the data source names and the values being the IDs.
        /// </summary>
        [JsonPropertyName("external_ids")]
        public IDictionary<string, string> ExternalIds { get; set; }


        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        /// <summary>
        /// An approximate distance to the origin location, in meters.
        /// Only provided when origin and navigation_profile are used in the request.
        /// </summary>
        [JsonPropertyName("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// The estimated time of arrival from the origin point to the feature, in minutes.
        /// Only provided when eta_type, origin, and navigation_profile are used in the request.
        /// If an address is not on the road network, an ETA will not be provided.
        /// </summary>
        [JsonPropertyName("eta")]
        public double? ETA { get; set; }

        /// <summary>
        /// The distance added to an input route by including the given suggestion, in meters.
        /// </summary>
        [JsonPropertyName("added_distance")]
        public double? AddedDistance { get; set; }

        /// <summary>
        /// The estimated time added to an input route by including the given suggestion, in minutes.
        /// </summary>
        [JsonPropertyName("added_time")]
        public double? AddedTime { get; set; }
    }
}
