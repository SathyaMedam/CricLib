namespace CricketLibrary.Model
{
    public class Toss
    {
        public int TeamWonTossId { get; set; }
        public string TeamWonToss { get; set; }
        public string TossDecisionType { get; set; }
    }
    public enum TossDecisionType
    {
        Batting,
        Bowling
    }
}
