using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WelcomeToUzbekistan.Entities.Regions;

internal class RegionsData
{
    [JsonProperty("current_page")]
    public int CurrentPage { get; set; }

    [JsonProperty("data")]
    public List<Region> Data { get; set; }
}
