using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using XyloCode.ThirdPartyServices.Mapbox.SearchBox.Models;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox
{
    public sealed class SearchBoxClient
    {
        readonly HttpClient httpClient;
        readonly JsonSerializerOptions jso;
        readonly string AccessToken;

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">A Mapbox access token with default permissions.</param>
        public SearchBoxClient(string accessToken)
        {
            AccessToken = accessToken;
            httpClient = new HttpClient();

            jso = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jso.Converters.Add(new JsonStringEnumConverter());
        }


        private string sessionToken;
        private long timeStamp = 0;
        private int suggestCnt = 0;
        private int retrieveCnt = 0;
        private bool SessionExpired =>  DateTime.Now.Ticks - timeStamp > 36000000000L;
        private void RefreshSessionToken()
        {
            sessionToken = Guid.NewGuid().ToString();
            suggestCnt = 0;
            retrieveCnt = 0;
        }

        private TResponse Request<TResponse>(string baseUri, UrlParams urlParams)
            where TResponse : class, new()
        {
            int attempts = 3;
            HttpResponseMessage respMsg = null!;
            string content;

            urlParams["access_token"] = AccessToken;
            string requestUri = baseUri + "?" + urlParams.ToString();

            while (--attempts > 0)
            {
                try
                {
                    respMsg = httpClient.GetAsync(requestUri).Result;
                    content = respMsg.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1000);
                    continue;
                }

                switch (respMsg.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return JsonSerializer.Deserialize<TResponse>(content, jso);

                    default:
                        throw new Exception(respMsg.StatusCode.ToString());
                }

            };
            return null;
        }


        /// <summary>
        /// This endpoint provides a list of suggested search results for the user query.
        /// This endpoint, along with the /retrieve endpoint, can be used to add autocomplete search functionality to your applications.
        /// </summary>
        /// <param name="query">The user's query string. The query is limited to 256 characters.</param>
        /// <param name="language">The ISO language code to be returned. If not provided, the default is English.</param>
        /// <param name="limit">The number of results to return, up to 10.</param>
        /// <param name="proximity">Bias the response to favor results that are closer to a specific location. Provide either ip to get results closest to the user's IP location or provide two comma-separated coordinates in longitude,latitude order. If not provided, the default is IP proximity. When both proximity and origin are provided, origin is interpreted as the target of a route, while proximity indicates the current user location.</param>
        /// <param name="origin">The location from which to calculate distance, provided as two comma-separated coordinates in longitude,latitude order. When both proximity and origin are provided, origin is interpreted as the target of a route, while proximity indicates the current user location. This parameter is required for distance-to-target estimates, but may incur additional latency.</param>
        /// <param name="bbox">Limit results to only those contained within the supplied bounding box. Bounding boxes should be supplied as four numbers separated by commas, in minimum longitude,minimum latitude,maximum longitude,maximum latitude order. The bounding box cannot cross the 180th meridian.</param>
        /// <param name="navigationProfile">The navigation routing profile to use. Available profiles are: driving, walking, and cycling. navigation_profile and origin are required for distance calculations.</param>
        /// <param name="route">A polyline encoded linestring describing the route to be used for searching. This parameter enables searching along a route. Both polyline5 and polyline6 precision are accepted, but must be specified using the route_geometry parameter.</param>
        /// <param name="routeGeometry">Passed in conjunction with a route polyline describing its precision. Options are polyline or polyline6. If this parameter is not provided with a route, the default is polyline. Accurate results depend on including the correct route_geometry for the route provided.</param>
        /// <param name="sarType">This indicates that the user intends to perform a higher cost search-along-route request. This should be included when route is included and should have a value of isochrone.</param>
        /// <param name="timeDeviation">Maximum detour in estimated minutes from route.</param>
        /// <param name="etaType">Used to estimate the time of arrival from the location specified in origin. The only allowed value for this parameter is navigation. This parameter, along with origin and navigation_profile, is required for ETA calculations. ETA calculations will incur additional latency.</param>
        /// <param name="country">An ISO 3166 alpha 2 country code.</param>
        /// <param name="types">Limit results to one or more types of features, provided as a comma-separated list. Pass one or more of the type names as a comma separated list. If no types are specified, all possible types may be returned. Available types are: country, region, postcode, district, place, city, locality, neighborhood, street, and address. See the Administrative unit types section for details about these types.</param>
        /// <param name="poiCategory">Limit results to those that belong to one or more categories, provided as a comma-separated list.</param>
        /// <param name="radius">Radius for the area to search within around a point.</param>
        /// <param name="userId">A customer provided user id.</param>
        /// <param name="richMetadataProvider">A comma-separated list of rich metadata providers to include in a suggestion result.</param>
        /// <param name="poiCategoryExclusions">A comma-separated list of canonical category names that limits POI results to those that are not part of the given categories.</param>
        /// <returns></returns>
        public SuggestionResult Search(
            string query,
            string language = null!,
            int? limit = 10,
            string proximity = null!,
            string origin = null!,
            string bbox = null!,
            string navigationProfile = null!,
            string route = null!,
            string routeGeometry = null!,
            string sarType = null!,
            int? timeDeviation = null!,
            string etaType = null!,
            string country = null!,
            string types = null!,
            string poiCategory = null!,
            int? radius = null,
            string userId = null!,
            string richMetadataProvider = null!,
            string poiCategoryExclusions = null!)
        {
            
            var q = new UrlParams
            {
                ["q"] = query,
                ["language"] = language,
                ["limit"] = limit?.ToString(),
                ["proximity"] = proximity,
                ["origin"] = origin,
                ["bbox"] = bbox,
                ["navigation_profile"] = navigationProfile,
                ["route"] = route,
                ["route_geometry"] = routeGeometry,
                ["sar_type"] = sarType,
                ["time_deviation"] = timeDeviation?.ToString(),
                ["eta_type"] = etaType,
                ["country"] = country,
                ["types"] = types,
                ["poi_category"] = poiCategory,
                ["radius"] = radius?.ToString(),
                ["user_id"] = userId,
                ["rich_metadata_provider"] = richMetadataProvider,
                ["poi_category_exclusions"] = poiCategoryExclusions
            };
            
            lock (sessionToken)
            {
                if (suggestCnt > 50 | retrieveCnt > 0 || SessionExpired)
                    RefreshSessionToken();
        
                q["session_token"] = sessionToken;
                suggestCnt++;
            }

            return Request<SuggestionResult>("https://api.mapbox.com/search/searchbox/v1/suggest", q);
        }


        /// <summary>
        /// The /retrieve endpoint provides detailed information about a feature including geographic coordinates.
        /// In a search session, this endpoint is called when the user selects an item from the suggested results provided by /suggest endpoint.
        /// </summary>
        /// <param name="id">After a successful call to the /suggest endpoint, you will use the ID contained in a suggestion's mapbox_id property to retrieve detailed information about the feature.</param>
        /// <returns></returns>
        public RetrieveResult Retrieve(string id)
        {
            var q = new UrlParams();

            lock (sessionToken)
            {
                if (SessionExpired)
                    RefreshSessionToken();

                q["session_token"] = sessionToken;
                retrieveCnt++;
            }
            
            return Request<RetrieveResult>("https://api.mapbox.com/search/searchbox/v1/retrieve/" + id, q); ;
        }
    }
}
