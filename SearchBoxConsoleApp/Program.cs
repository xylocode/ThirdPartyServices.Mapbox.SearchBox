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
                var retrieve = searchBox.Retrieve(suggestion.MapboxId);
                foreach (var feature in retrieve.Features)
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