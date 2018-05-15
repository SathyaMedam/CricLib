using System.Collections.Generic;
using CricketLibrary.Model;

namespace CricketLibrary.Data
{
    public class Matches
    {
        public static List<Match> GetMatches()
        {

            var match1 = new Match { MatchId = 12345, Team1Id = 10990, Name = "India v Australia", Team2Id = 34590, MatchStatus = MatchStatus.Scheduled, FormatType = FormatType.ODI, NumberOfOvers = 45, WideValue = 1,NoBallValue = 1,NumberOfPlayersPerTeam = 11};
            var match2 = new Match { MatchId = 54321, Team1Id = 28990, Name = "England v Australia", Team2Id = 34590, MatchStatus = MatchStatus.Scheduled, FormatType = FormatType.ODI, NumberOfOvers = 45, WideValue = 1,NoBallValue = 1,NumberOfPlayersPerTeam = 11};
            var match3 = new Match { MatchId = 54321, Team1Id = 67890, Name = "South Africa v India", Team2Id = 10990, MatchStatus = MatchStatus.Scheduled, FormatType = FormatType.ODI, NumberOfOvers = 45, WideValue = 1, NoBallValue = 1, NumberOfPlayersPerTeam = 11 };
            return new List<Match> { match1, match2, match3 };
        }
    }
}
