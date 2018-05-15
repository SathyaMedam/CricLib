
namespace CricketLibrary.Model
{
    public class Ball
    {
        public int BallNumber { get; set; }
        public int BallAttemptNumber { get; set; }
        public BallType BallType { get; set; }
        public RunsType RunsType { get; set; }
        public BallAttemptStatus BallAttemptStatus { get; set; }
        public bool IsFinished { get; set; }
        public int Runs { get; set; }
        public int Extras { get; set; }
        public BoundaryType BoundaryType { get; set; }
        public bool IsDismissal { get; set; }
        public DisMissalType DisMissalType { get; set; }
        public int BowlerId { get; set; }
        public int BatsmenId { get; set; }
        public int FielderId { get; set; }

        //public BowlingTeamPlayer Bowler { get; set; }
        //public BattingTeamPlayer Batsmen { get; set; }
        //public BowlingTeamPlayer Fielder { get; set; }


    }

    public enum BallType
    {
        Wide,
        NoBall,
        DeadBall,
        Legitimate
    }

    public enum BallAttemptStatus
    {
        NotStarted,
        InProgress,
        Finished
    }

    public enum DisMissalType
    {
        None,
        Bowled,
        Caught,
        RunOut,
        StumpOut,
        HitWicket,
        Lbw,
        HandledTheBall,
        Mankad,
        TimedOut,
        RetiredOut
    }

    public enum RunsType
    {
        Wide,
        NoBall,
        Run,
        Byes,
        LegByes
    }
    public enum BoundaryType
    {
        None,
        Four,
        Six
    }
}
