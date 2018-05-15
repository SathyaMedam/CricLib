using Newtonsoft.Json;

namespace CricketLibrary.Model
{
    public class Player
    {
        [JsonProperty(Order = -1)]
        public int Id { get; set; }
        [JsonProperty(Order = -1)]
        public string Name { get; set; }
        [JsonProperty(Order = -1)]
        public PlayerRole PlayerRole { get; set; }
        [JsonIgnore]
        public bool IsSerializePlayerRoler { get; set; } = true;
        public bool ShouldSerializePlayerRole()
        {
            return this.IsSerializePlayerRoler;
        }
        
    }
}
