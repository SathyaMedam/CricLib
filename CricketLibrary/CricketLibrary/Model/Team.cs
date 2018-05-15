using System.Collections.Generic;
using Newtonsoft.Json;

namespace CricketLibrary.Model
{
    public class Team
    {
        [JsonProperty(Order = -2)]
        public int Id { get; set; }
        [JsonProperty(Order = -2)]
        public string Name { get; set; }
    }
}
