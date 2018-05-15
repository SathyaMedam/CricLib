namespace CricketLibrary.Model
{
    public class BowlingTeamPlayer :CricketPlayer
    {
        public int OversBowled { get; set; }
        public int BallsBowled { get; set; }
        public int RunsConceded { get; set; }
        public int NumberOfFoursConceded { get; set; }
        public int NumberOfSixersConceded { get; set; }
        public int NumberOfDotBallsBowled { get; set; }
        public int NumberOfWidesBowled { get; set; }
        public int NumberOfNoBallsBowled { get; set; }
        public int NumberOfMaidensBowled { get; set; }
        public int NumberOfzerosBowled { get; set; }
        public int NumberOfWickets { get; set; }
        public BowlingTeamPlayer(CricketPlayer player) : base(player)
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
