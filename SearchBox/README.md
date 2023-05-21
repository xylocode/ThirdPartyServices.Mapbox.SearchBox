# Search Box API Client
 
An unofficial client library for accessing the Mapbox Search Box API.

Support only `/suggest` and `/retrieve` endpoints are used together to build an Interactive Search for your app.

## Mapbox

Mapbox is an American provider of custom online maps for websites and applications such as Foursquare, Lonely Planet, the Financial Times, The Weather Channel, Instacart Inc. and Snapchat. Since 2010, it has rapidly expanded the niche of custom maps, as a response to the limited choice offered by map providers such as Google Maps.

Official website:

- [https://www.mapbox.com/](https://www.mapbox.com/)

## Search Box

Search millions of continuously updated locations, including addresses, places, and points of interest, with a single search box. The Search Box API serves 340 Million+ addresses and 170 Million+ POIs with ever-improving coverage and quality on a global scale.

Official website:

- [Product Information](https://www.mapbox.com/search-box)
- [Documentation](https://docs.mapbox.com/api/search/search-box/)

## Session token generation

Pricing for the Mapbox Search Box API is based on which API endpoints are used.
If you are using the `/suggest` or `/retrieve` endpoints, usage will be billed per search session.

The `session_token` is generated automatically based on the rules of the service.

A Search Session is a series of Search API calls bundled together for billing purposes. The `session_token` parameter is used to group a series of requests together into one session for billing purposes.

A session ends after the following actions:

- A call is made to `/suggest` followed by a call to `/retrieve` with a common `session_token`.
- 50 successive calls are made to `/suggest` with a common `session_token` but are not followed by a call to `/retrieve`.
- A call is made to `/suggest` and 60 minutes pass without being followed by a call to `/retrieve`.

## How to use

```cs
using XyloCode.ThirdPartyServices.Mapbox.SearchBox;

namespace SearchBoxConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string accessToken = "Default public token from https://account.mapbox.com/";
            string searchText = "671 Lincoln Ave";
            
            var searchBox = new SearchBoxClient(accessToken);
            var searchResult = searchBox.Search(searchText, country: "US");
            foreach (var suggestion in searchResult.Suggestions)
            {
                Console.WriteLine(suggestion.FullAddress);
                var retrive = searchBox.Retrieve(suggestion.MapboxId);
                foreach (var feature in retrive.Features)
                {
                    Console.WriteLine("{0} {1}", feature.Properties.Coordinates.Latitude, feature.Properties.Coordinates.Longitude);
                }
                Console.WriteLine("===*****===");

            }
            Console.Beep();
            Console.WriteLine("End!");
        }
    }
}
```