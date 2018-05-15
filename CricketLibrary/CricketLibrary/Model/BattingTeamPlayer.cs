using System;

namespace CricketLibrary.Model
{
    public class BattingTeamPlayer : CricketPlayer
    {
        public int Runs { get; set; }
        public int BallsFaced { get; set; }
        public DateTime TimeAtCrease { get; set; }
        public int NumberOfDotBalls { get; set; }
        public int NumberOfFours { get; set; }
        public int NumberOfSixers { get; set; }
        public int RunsScoredInBoundaries => (NumberOfFours * 4) + (NumberOfSixers * 6);
        public decimal StrikeRate
        {
            get
            {
                if (BallsFaced > 0)
                {
                    return ((Runs * 100) / BallsFaced);
                }

                return 0;
            }
        }
        public bool Dismissed { get; set; }
        public BattingTeamPlayer(CricketPlayer player) : base(player)
        {
            if (player != null)
            {
                this.Id = player.Id;
                this.Name = player.Name;
                this.PlayerRole = player.PlayerRole;
                this.IsSerializePlayerRoler = false;
            }

        }
    }
}
