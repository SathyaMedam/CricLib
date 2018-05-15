using System.Collections.Generic;
using Newtonsoft.Json;

namespace CricketLibrary.Model
{
    public class CricketTeam : Team
    {
        [JsonIgnore]
        public int TeamInningsNumber { get; set; }
        [JsonProperty(Order = 2)]
        public List<CricketPlayer> Players { get; set; }
        public bool IsHomeTeam { get; set; }
        public bool IsTeam1 { get; set; }
        public CricketTeam(Team team)
        {
            if (team != null)
            {
                this.Id = team.Id;
                this.Name = team.Name;
            }

            Players = new List<CricketPlayer>();
        }
    }
}
