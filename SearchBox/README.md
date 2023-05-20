# Search Box API Client
 
An unofficial client library for accessing the Mapbox Search Box API.

Support only `/suggest` and `/retrieve` endpoints are used together to build an Interactive Search for your app.

## Mapbox

Mapbox is an American provider of custom online maps for websites and applications such as Foursquare, Lonely Planet, the Financial Times, The Weather Channel, Instacart Inc. and Snapchat. Since 2010, it has rapidly expanded the niche of custom maps, as a response to the limited choice offered by map providers such as Google Maps.

Official website:
[https://www.mapbox.com/](https://www.mapbox.com/)

## Search Box

Search millions of continuously updated locations, including addresses, places, and points of interest, with a single search box. The Search Box API serves 340 Million+ addresses and 170 Million+ POIs with ever-improving coverage and quality on a global scale.

Official website:

- [Product Information](https://www.mapbox.com/search-box)
- [Documentation](https://docs.mapbox.com/api/search/search-box/)

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