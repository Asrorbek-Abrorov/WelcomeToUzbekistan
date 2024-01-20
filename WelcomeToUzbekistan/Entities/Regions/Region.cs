using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WelcomeToUzbekistan.Entities.Regions;

internal class Region
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name_uz")]
    public string Name { get; set; }
}
