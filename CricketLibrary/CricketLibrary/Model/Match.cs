namespace CricketLibrary.Model
{
    public class Match
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public int MatchId { get; set; }
        public string Name { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public string MatchStatusName => MatchStatus.ToString();
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public FormatType FormatType { get; set; }
        public int NumberOfOvers { get; set; }
        public int WideValue { get; set; }
        public int NoBallValue { get; set; }
        public int NumberOfPlayersPerTeam { get; set; }

    }
}
