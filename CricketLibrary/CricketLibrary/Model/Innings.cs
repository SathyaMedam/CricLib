using Newtonsoft.Json;
using System.Collections.Generic;

namespace CricketLibrary.Model
{
    public class Innings
    {
        public int InningsNumber { get; set; }
        public string InningsName { get; set; }
        public int BattingTeamId { get; set; }
        public int BowlingTeamId { get; set; }
        public InningsStatus InningsStatus { get; set; }
        public int Runs { get; set; }
        public int Wickets { get; set; }
        public string NumberOfOversBowled { get; set; }
        public int Wides { get; set; }
        public int WideRuns { get; set; }
        public int NoBallRuns { get; set; }
        public int NoBalls { get; set; }
        public int Byes { get; set; }
        public int Legbyes { get; set; }
        public int PenaltyRuns { get; set; }
        public int NumberOfFours { get; set; }
        public int NumberOfSixers { get; set; }
        public int NumberOfDotBalls { get; set; }
        public int TotalExtras => WideRuns + NoBallRuns + Byes + Legbyes + PenaltyRuns;
        public int TotalRuns => Runs + TotalExtras;
        public List<BattingTeamPlayer> BattingTeamPlayers { get; set; }
        public List<BowlingTeamPlayer> BowlingTeamPlayers { get; set; }
        public BattingTeamPlayer Striker { get; set; }
        public BattingTeamPlayer NonStriker { get; set; }
        public List<Over> Overs { get; set; }
        [JsonIgnore]
        public List<TimelineAction> TimelineActions { get; set; }
        //   [JsonIgnore]

        public Innings()
        {
            Overs = new List<Over>();
            TimelineActions = new List<TimelineAction>();
            BattingTeamPlayers = new List<BattingTeamPlayer>();
            BowlingTeamPlayers = new List<BowlingTeamPlayer>();
        }

    }

    public enum InningsStatus
    {
        NotStarted,
        InProgress,
        Break,
        Finished
    }
}
