namespace CricketLibrary.Model
{
    public class TeamInningsScoreCard
    {
        public int Runs { get; set; }
        public int Wickets { get; set; }
        public string Overs { get; set; }
        public int Wides { get; set; }
        public int WideRuns { get; set; }
        public int NoBallRuns { get; set; }
        public int NoBalls { get; set; }
        public int Byes { get; set; }
        public int Legbyes { get; set; }
        public int PenaltyRuns { get; set; }
        public int TotalExtras => WideRuns + NoBallRuns + Byes + Legbyes + PenaltyRuns;
        public int TotalRuns => Runs + TotalExtras;

    }
}
