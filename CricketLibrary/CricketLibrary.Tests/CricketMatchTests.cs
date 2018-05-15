using System.Collections.Generic;
using System.Linq;
using CricketLibrary.Data;
using CricketLibrary.Model;
using CricketLibrary.Model.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CricketLibrary.Tests
{
    [TestClass]
    public class CricketMatchTests
    {
        [TestMethod]
        public void GetListOfSeasons()
        {
            var seasonList = Seasons.GetSeasons();
            var sd = JsonConvert.SerializeObject(seasonList);
            var d = JsonConvert.DeserializeObject<List<Match>>(sd); ;
            Assert.IsTrue(seasonList.Count > 0);
        }
        [TestMethod]
        public void CreateTeam()
        {
            var team1 = new Team { Id = 10990, Name = "India" };
            var sd = JsonConvert.SerializeObject(team1);
            var d = JsonConvert.DeserializeObject<Team>(sd);
            Assert.IsTrue(team1 != null);
        }
        [TestMethod]
        public void GetListOfTeams()
        {
            var teams = Teams.GetTeams();
            var sd = JsonConvert.SerializeObject(teams);
            var d = JsonConvert.DeserializeObject<List<Team>>(sd); ;
            Assert.IsTrue(teams.Count > 0);
        }
        [TestMethod]
        public void CreateMatch()
        {
            var matf = new List<Match>();
            var match1 = new Match { MatchId = 12345, Team1Id = 10000, Team2Id = 11111, MatchStatus = MatchStatus.Scheduled };
            var sd = JsonConvert.SerializeObject(match1);
            var d = JsonConvert.DeserializeObject<Match>(sd);
            matf.AddRange(Matches.GetMatches());
            matf.Add(match1);
            var maths = matf.Count;
            Assert.IsTrue(match1 != null);
        }

        [TestMethod]
        public void GetListOfMatch()
        {
            var matches = Matches.GetMatches();
            var sd = JsonConvert.SerializeObject(matches);
            var d = JsonConvert.DeserializeObject<List<Match>>(sd); ;
            Assert.IsTrue(matches.Count > 0);
        }

        [TestMethod]
        public void ConfirmMatchInfoAndStartMatch()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd); ;
            Assert.IsTrue(match != null);
        }

        //[TestMethod]
        //public void CreatePlayer()
        //{
        //    var player = new Player { Id = 90000, Name = "Sathya" };
        //    var sd = JsonConvert.SerializeObject(player);
        //    var d = JsonConvert.DeserializeObject<Player>(sd);
        //    Assert.IsTrue(player != null);
        //}
        //[TestMethod]
        //public void GetListOfPlayers()
        //{
        //    var homePlayers = Players.GetPlayers();
        //    var sd = JsonConvert.SerializeObject(homePlayers);
        //    var d = JsonConvert.DeserializeObject<List<Player>>(sd); ;
        //    Assert.IsTrue(homePlayers.Count > 0);
        //}


        [TestMethod]
        public void CoinToss()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }

        [TestMethod]
        public void SelectMatchPlayersFromSquad()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }

        [TestMethod]
        public void StartInnings()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void SelectStrikerAndNonStrikerBatsman()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();

            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void StartOver()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void Balls()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Wide, RunsType.Wide, BoundaryType.None, 2, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.NoBall, RunsType.NoBall, BoundaryType.None, 2, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.NoBall, RunsType.Run, BoundaryType.None, 2, ap3, p1, false, null, null, DisMissalType.None);
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }

        [TestMethod]
        public void UndoBall()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Wide, RunsType.Wide, BoundaryType.None, 2, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.NoBall, RunsType.NoBall, BoundaryType.None, 2, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.NoBall, RunsType.Run, BoundaryType.None, 2, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.UndoBall();

            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }

        [TestMethod]
        public void Dismissal()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            var ap4 = awayPlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap3, p1, true, p1, ap4, DisMissalType.Caught);

            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void EndOver()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            var ap4 = awayPlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap3, p1, true, p1, ap4, DisMissalType.Caught);
            cricketMatch.EndOver();
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }

        [TestMethod]
        public void EndInnings()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            var ap4 = awayPlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap3, p1, true, p1, ap4, DisMissalType.Caught);
            cricketMatch.EndOver();
            cricketMatch.EndInnings();
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void InningsBreak()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            var ap4 = awayPlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap3, p1, true, p1, ap4, DisMissalType.Caught);
            cricketMatch.EndOver();
            cricketMatch.EndInnings();
            cricketMatch.SetMatchStatus(MatchStatus.Break);
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void StartSecondInnings()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            var ap4 = awayPlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap3, p1, true, p1, ap4, DisMissalType.Caught);
            cricketMatch.EndOver();
            cricketMatch.EndInnings();
            cricketMatch.StartInnings();
            cricketMatch.SetMatchStatus(MatchStatus.Break);
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void EndMatch()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            var ap4 = awayPlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap3, p1, true, p1, ap4, DisMissalType.Caught);
            cricketMatch.UndoBall();
            cricketMatch.EndOver();
            cricketMatch.EndInnings();
            cricketMatch.StartInnings();
            cricketMatch.SetMatchStatus(MatchStatus.Break);
            cricketMatch.EndMatch();
            var jMatch = new { CricketMatch = cricketMatch };
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
        [TestMethod]
        public void EndMatch1()
        {
            var match = Matches.GetMatches().First(x => x.MatchId == 12345);
            match.NumberOfOvers = 40;
            var cricketMatch = new CricketMatch(match);
            cricketMatch.Teams.FirstOrDefault().IsHomeTeam = true;
            cricketMatch.CoinToss(10990, TossDecisionType.Batting);
            var homePlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            var awayPlayers = Players.GetPlayers().Where(x => x.PlayerRole.TeamId != 10990).Take(4)
                .Select(x => new CricketPlayer(x)).ToList();
            cricketMatch.Teams.First(x => x.IsHomeTeam).Players = homePlayers;
            cricketMatch.Teams.First(x => !x.IsHomeTeam).Players = awayPlayers;
            cricketMatch.StartInnings();
            var p1 = homePlayers.FirstOrDefault();
            var p2 = homePlayers.LastOrDefault();
            var ap3 = awayPlayers.FirstOrDefault();
            var ap4 = awayPlayers.LastOrDefault();
            cricketMatch.SetStrikerNonStrikerBatsmen(p1, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(p2, false);
            cricketMatch.StartOver(ap3);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.Four, 4, ap3, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap3, p1, true, p1, ap4, DisMissalType.Caught);

            cricketMatch.EndOver();
            cricketMatch.StartOver(ap4);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 1, ap4, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap4, p1, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, ap4, p1, false, null, null, DisMissalType.None);
            cricketMatch.EndOver();
            cricketMatch.EndInnings();

            cricketMatch.StartInnings();
            cricketMatch.SetStrikerNonStrikerBatsmen(ap3, true);
            cricketMatch.SetStrikerNonStrikerBatsmen(ap4, false);
            cricketMatch.StartOver(p1);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 1, p1, ap4, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, p1, ap4, false, null, null, DisMissalType.None);
            cricketMatch.AddBall(BallType.Legitimate, RunsType.Run, BoundaryType.None, 0, p1, ap4, false, null, null, DisMissalType.None);
            cricketMatch.EndOver();
            cricketMatch.EndInnings();

            // cricketMatch.EnforcedFollowOn = true;

            cricketMatch.StartInnings();
            cricketMatch.EndInnings();
            cricketMatch.StartInnings();
            cricketMatch.EndInnings();
            cricketMatch.EndMatch();
            var jMatch = new { CricketMatch = cricketMatch };
            var sd = JsonConvert.SerializeObject(cricketMatch);
            var d = JsonConvert.DeserializeObject<CricketMatch>(sd);
            Assert.IsTrue(cricketMatch != null);
        }
    }
}
