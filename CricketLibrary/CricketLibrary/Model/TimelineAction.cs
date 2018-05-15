namespace CricketLibrary.Model
{
   public class TimelineAction
    {
        public int InningsNumber { get; set; }
        public int OverNumber { get; set; }
        public int BallNumber { get; set; }
        public int BallAttemptNumber { get; set; }
        public int Runs { get; set; }
        public BallType BallType { get; set; }
        public RunsType RunsType { get; set; }
        public int BowlerId { get; set; }
        public int BatsmenId { get; set; }
        public int FielderId { get; set; }
        //public BattingTeamPlayer Batsman { get; set; }
        //public BowlingTeamPlayer Bowler { get; set; }
        //public BowlingTeamPlayer Fielder { get; set; }
    }
}
