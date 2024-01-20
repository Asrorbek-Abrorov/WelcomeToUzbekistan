using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WelcomeToUzbekistan.Entities.Places;
using WelcomeToUzbekistan.Entities.Regions;

namespace WelcomeToUzbekistan
{
    namespace WelcomeToUzbekistan
    {
        internal class Uzbekistan
        {
            public List<Region> Regions { get; private set; } // Added Regions property

            public async Task Run()
            {
                string UzbekistanUrl = "https://api.uzheritage.org/api/v1/regions?&_f=json&_l=uz";

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(UzbekistanUrl);

                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RegionsData>(content);
                Regions = result.Data; // Assign regions to the Regions property

                foreach (var region in Regions)
                {
                    Console.WriteLine(region.Name + " " + region.Id);
                }
            }

            public async Task<List<HistoricalPlaces>> GetHistoricalPlacesByRegion(int regionId)
            {
                string placesUrl = $"https://api.uzheritage.org/api/v1/objects?region_id={regionId}&append=photo&include=type,region&per_page=16&sort=-updated_at&_f=json&_l=uz";

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(placesUrl);
                string content = await response.Content.ReadAsStringAsync();

                var historicalPlaces = JsonConvert.DeserializeObject<HPData>(content);
                return historicalPlaces.Data;
            }
        }
    }
}