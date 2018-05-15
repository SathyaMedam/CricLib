using System;
using Newtonsoft.Json;

namespace CricketLibrary.Model
{
    public class CricketPlayer : Player
    {
        public bool IsCaptian { get; set; }
        public bool IsWicketKeeper { get; set; }

        public CricketPlayer(Player player)
        {
            if (player != null)
            {
                this.Id = player.Id;
                this.Name = player.Name;
                this.PlayerRole = player.PlayerRole;
            }
        }
      
    }    
}
