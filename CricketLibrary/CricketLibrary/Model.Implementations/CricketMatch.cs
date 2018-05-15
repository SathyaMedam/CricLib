using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CricketLibrary.Data;
using Newtonsoft.Json;

namespace CricketLibrary.Model.Implementations
{
    public class CricketMatch : Match, ICricketMatch, IInnings
    {

        [JsonProperty(Order = 1)]
        public List<CricketTeam> Teams { get; set; }
        [JsonProperty(Order = 2)]
        public Toss Toss { get; set; }
        [JsonProperty(Order = 3)]
        public List<Innings> Innings { get; set; }
        [JsonProperty(Order = 4)]
        public bool EnforcedFollowOn { get; set; }


        public CricketMatch(Match match)
        {
            if (this.Innings == null)
            {
                this.Innings = new List<Innings>();
            }

            this.Toss = new Toss();
            if (match != null)
            {
                this.MatchId = match.MatchId;
                this.Team1Id = match.Team1Id;
                this.Team2Id = match.Team2Id;
                this.FormatType = match.FormatType;
                this.WideValue = match.WideValue;
                this.NoBallValue = match.NoBallValue;
                this.NumberOfOvers = match.NumberOfOvers;
                this.NumberOfPlayersPerTeam = match.NumberOfPlayersPerTeam;
                this.MatchStatus = match.MatchStatus;

                var teams = Data.Teams.GetTeams();
                var crTeam1 = new CricketTeam(teams.FirstOrDefault(x => x.Id == match.Team1Id));
                var crTeam2 = new CricketTeam(teams.FirstOrDefault(x => x.Id == match.Team2Id));
                crTeam1.Players = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == match.Team1Id).Select(y => new CricketPlayer(y)).ToList();
                crTeam2.Players = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == match.Team2Id).Select(y => new CricketPlayer(y)).ToList();
                this.Teams = new List<CricketTeam> { crTeam1, crTeam2 };
                this.Name = crTeam1.Name + " v " + crTeam2.Name;
            }


        }

        public CricketMatch CreateInstanceOfCricketMatch(Match match)
        {
            var cricketMatch =new CricketMatch(match);
            if (this.Innings == null)
            {
                this.Innings = new List<Innings>();
            }

            this.Toss = new Toss();
            if (match != null)
            {
                this.MatchId = match.MatchId;
                this.Team1Id = match.Team1Id;
                this.Team2Id = match.Team2Id;
                this.FormatType = match.FormatType;
                this.WideValue = match.WideValue;
                this.NoBallValue = match.NoBallValue;
                this.NumberOfPlayersPerTeam = match.NumberOfPlayersPerTeam;
                this.MatchStatus = match.MatchStatus;

                var teams = Data.Teams.GetTeams();
                var crTeam1 = new CricketTeam(teams.FirstOrDefault(x => x.Id == match.Team1Id));
                var crTeam2 = new CricketTeam(teams.FirstOrDefault(x => x.Id == match.Team2Id));
                crTeam1.Players = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == match.Team1Id).Select(y => new CricketPlayer(y)).ToList();
                crTeam2.Players = Players.GetPlayers().Where(x => x.PlayerRole.TeamId == match.Team2Id).Select(y => new CricketPlayer(y)).ToList();
                this.Teams = new List<CricketTeam> { crTeam1, crTeam2 };
                this.Name = crTeam1.Name + " v " + crTeam2.Name;
            }

            return cricketMatch;
        }


        //public CricketMatch GetMatch(int matchId)
        //{
        //    var match = Matches.GetMatches().FirstOrDefault(x => x.MatchId == matchId);
        //    var cricketMatch = new CricketMatch
        //    {
        //        MatchId = match.MatchId
        //    };
        //    var teams = Teams.GetTeams()
        //        var crTeam1 = new CricketTeam(Teams.ge.FirstOrDefault(x => x.Id == match1.Team1Id));
        //    var crTeam2 = new CricketTeam(teams.FirstOrDefault(x => x.Id == match1.Team2Id));
        //    cricketMatch = new CricketMatch(match1) { Teams = new List<CricketTeam> { crTeam1, crTeam2 } };
        //    cricketMatch.Teams =
        //        cricketMatch.Innings = new List<Innings>()
        //        return cricketMatch;

        //}

        //public void AddPlayersToTeam(List<int> selectdPlayerIds, bool isHomeTeam)
        //{
        //    if (isHomeTeam)
        //    {
        //        foreach (var selectdPlayerId in selectdPlayerIds)
        //        {
        //            var player = this.Match.HomePlayers.FirstOrDefault(x => x.Id == selectdPlayerId);
        //            var cricketPlayer = new CricketPlayer(player);
        //            this.HomeTeam.Players.Add(cricketPlayer);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var selectdPlayerId in selectdPlayerIds)
        //        {
        //            var player = this.Match.AwayPlayers.FirstOrDefault(x => x.Id == selectdPlayerId);
        //            var cricketPlayer = new CricketPlayer(player);
        //            this.AwayTeam.Players.Add(cricketPlayer);
        //        }
        //    }

        //}

        public CricketTeam CurrentBattingTeam()
        {
            var innings = this.CurrentInnings();
            if (innings != null)
            {
                return this.Teams.FirstOrDefault(x => x.Id == this.CurrentInnings().BattingTeamId);
            }
            return null;
        }
        public CricketTeam CurrentBowlingTeam()
        {
            var innings = this.CurrentInnings();
            if (innings != null)
            {
                return this.Teams.FirstOrDefault(x => x.Id == this.CurrentInnings().BowlingTeamId);
            }
            return null;
        }

        public Innings CurrentInnings()
        {
            return this.Innings.FirstOrDefault(x => x.InningsStatus == InningsStatus.InProgress);

        }
        public Over CurrentOver()
        {
            return this.CurrentInnings().Overs.FirstOrDefault(x => x.OverStauts == OverStatus.OverInProgress);

        }
        public Ball CurrentBall()
        {
            return this.CurrentOver().Balls.FirstOrDefault(x => x.BallAttemptStatus == BallAttemptStatus.InProgress);

        }

        public void EndMatch()
        {
            this.MatchStatus = MatchStatus.Finished;
        }

        public void CoinToss(int teamWonId, TossDecisionType decisionType)
        {
            this.Toss.TeamWonTossId = teamWonId;
            this.Toss.TeamWonToss = this.Teams.FirstOrDefault(x => x.Id == teamWonId)?.Name;
            this.Toss.TossDecisionType = decisionType.ToString();
        }

        public void UndoBall()
        {
           var lastBall= this.CurrentOver().Balls.LastOrDefault();
            this.CurrentOver().Balls.Remove(lastBall);
        }

        public void StartOver(CricketPlayer bowler)
        {
            var newBowler = new BowlingTeamPlayer(bowler);
            CurrentInnings().BowlingTeamPlayers.Add(newBowler);
            var over = new Over
            {
                OverStauts = OverStatus.OverInProgress,
                //Bowler = player,
                Number = this.CurrentInnings().Overs.Count + 1,
                BowlerId = bowler.Id
            };

            CurrentInnings().Overs.Add(over);
        }

        public void EndOver()
        {
            CurrentOver().OverStauts = OverStatus.OverFinished;
            var striker = this.CurrentInnings().Striker;
            var nonStriker = this.CurrentInnings().NonStriker;
            this.CurrentInnings().Striker = nonStriker;
            this.CurrentInnings().NonStriker = striker;
        }

        public void EndInnings()
        {
            this.CurrentInnings().InningsStatus = InningsStatus.Finished;
            this.MatchStatus = MatchStatus.Break;
        }

        public void StartInnings()
        {
            var homeTeam = Teams.FirstOrDefault(x => x.IsHomeTeam || x.IsTeam1).Id;
            var awayTeam = Teams.FirstOrDefault(x => !x.IsHomeTeam).Id;
            Enum.TryParse(this.Toss.TossDecisionType, true, out TossDecisionType decisionType);
            var innings = new Innings
            {
                InningsNumber = this.Innings.Count() + 1,
                InningsStatus = InningsStatus.InProgress
            };
            switch (innings.InningsNumber)
            {
                case 1:
                    if (this.Toss.TeamWonTossId == homeTeam)
                    {
                        innings.BattingTeamId = decisionType == TossDecisionType.Batting ? homeTeam : awayTeam;
                        innings.BowlingTeamId = decisionType == TossDecisionType.Batting ? awayTeam : homeTeam;
                    }
                    else
                    {
                        innings.BattingTeamId = decisionType == TossDecisionType.Batting ? awayTeam : homeTeam;
                        innings.BowlingTeamId = decisionType == TossDecisionType.Batting ? homeTeam : awayTeam;
                    }

                    break;
                case 2:
                    var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 1);
                    if (finishedInnings != null && finishedInnings.BattingTeamId == homeTeam)
                    {
                        innings.BattingTeamId = awayTeam;
                        innings.BowlingTeamId = homeTeam;
                    }
                    else
                    {
                        innings.BattingTeamId = homeTeam;
                        innings.BowlingTeamId = awayTeam;
                    }

                    break;
            }

            if (this.EnforcedFollowOn)
            {
                switch (innings.InningsNumber)
                {
                    case 3:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 1);
                            if (finishedInnings != null && finishedInnings.BattingTeamId == homeTeam)
                            {
                                innings.BattingTeamId = awayTeam;
                                innings.BowlingTeamId = homeTeam;
                            }
                            else
                            {
                                innings.BattingTeamId = homeTeam;
                                innings.BowlingTeamId = awayTeam;
                            }

                            break;
                        }
                    case 4:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 1);
                            if (finishedInnings != null && finishedInnings.BattingTeamId == homeTeam)
                            {
                                innings.BattingTeamId = homeTeam;
                                innings.BowlingTeamId = awayTeam;
                            }
                            else
                            {
                                innings.BattingTeamId = awayTeam;
                                innings.BowlingTeamId = homeTeam;
                            }

                            break;
                        }
                }
            }
            else
            {
                switch (innings.InningsNumber)
                {
                    case 3:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 1);
                            if (finishedInnings != null && finishedInnings.BattingTeamId == homeTeam)
                            {
                                innings.BattingTeamId = homeTeam;
                                innings.BowlingTeamId = awayTeam;
                            }
                            else
                            {
                                innings.BattingTeamId = awayTeam;
                                innings.BowlingTeamId = homeTeam;
                            }

                            break;
                        }
                    case 4:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 2);
                            if (finishedInnings != null && finishedInnings.BattingTeamId == homeTeam)
                            {
                                innings.BattingTeamId = homeTeam;
                                innings.BowlingTeamId = awayTeam;
                            }
                            else
                            {
                                innings.BattingTeamId = awayTeam;
                                innings.BowlingTeamId = homeTeam;
                            }

                            break;
                        }
                }
            }

            this.MatchStatus = MatchStatus.InPlay;
            this.Innings.Add(innings);
            CurrentBattingTeam().TeamInningsNumber += 1;
            innings.InningsName = CurrentBattingTeam().Name + " " + AddOrdinal(CurrentBattingTeam().TeamInningsNumber) + " Innings";
        }



        public void AddBall(BallType ballType, RunsType runsType, BoundaryType boundaryType, int runs,
            CricketPlayer playerBowler, CricketPlayer playreBtsmen, bool isDismissal, CricketPlayer dismissedPlayer, CricketPlayer playerFielder, DisMissalType disMissalType)
        {
            var batsmen = this.CurrentInnings().BattingTeamPlayers.FirstOrDefault(x => x.Id == playreBtsmen.Id);
            var bowler = this.CurrentInnings().BowlingTeamPlayers.FirstOrDefault(x => x.Id == playerBowler.Id);


            var innings = this.CurrentInnings();
            var over = this.CurrentOver();
            var ball = new Ball
            {
                BallAttemptStatus = BallAttemptStatus.InProgress,
                BallType = ballType,
                RunsType = runsType,
                BoundaryType = boundaryType,
                Runs = runs,

                IsDismissal = isDismissal,
                DisMissalType = disMissalType,
            };
            if (batsmen != null) ball.BatsmenId = batsmen.Id;
            if (bowler != null) { ball.BowlerId = bowler.Id; bowler.BallsBowled++; }
            if (playerFielder != null) ball.FielderId = playerFielder.Id;
            switch (ball.BallType)
            {
                case BallType.Legitimate:
                    ball.BallNumber = CurrentOver().Balls.Count(x => x.IsFinished) + 1;
                    ball.BallAttemptNumber = 1;
                    ball.IsFinished = true;
                    innings.Runs += runs;
                    over.Runs += runs;
                    batsmen.BallsFaced++;
                    batsmen.Runs += runs;
                    bowler.RunsConceded += runs;
                    if (ball.Runs == 0)
                    {
                        batsmen.NumberOfDotBalls++;
                        bowler.NumberOfDotBallsBowled++;
                        innings.NumberOfDotBalls++;
                    }
                    break;
                case BallType.Wide:
                    ball.Extras = this.WideValue + runs;
                    ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                    ball.BallNumber = CurrentOver().Balls.Count(x => x.IsFinished);
                    innings.Wides += 1;
                    innings.WideRuns += this.WideValue + runs;
                    over.Extras += this.WideValue + runs;
                    bowler.NumberOfWidesBowled++;
                    bowler.RunsConceded += this.WideValue + runs;
                    break;
                case BallType.NoBall:
                    if (ball.RunsType == RunsType.Run)
                    {
                        ball.Extras = this.NoBallValue;
                        ball.Runs = runs;
                        innings.NoBallRuns += this.NoBallValue;
                        innings.Runs += runs;
                        batsmen.Runs += runs;
                    }
                    else
                    {
                        ball.Extras = this.NoBallValue + runs;
                        innings.NoBallRuns += this.NoBallValue + runs;
                    }
                    ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                    ball.BallNumber = CurrentOver().Balls.Count(x => x.IsFinished);
                    innings.NoBalls += 1;
                    over.Extras += this.NoBallValue + runs;
                    batsmen.BallsFaced++;
                    bowler.NumberOfNoBallsBowled++;
                    bowler.RunsConceded += this.NoBallValue + runs;
                    break;
            }

            switch (ball.RunsType)
            {
                case RunsType.Byes:
                    ball.Extras = runs;
                    ball.Runs = 0;
                    innings.Byes += runs;
                    over.Extras = runs;
                    break;
                case RunsType.LegByes:
                    ball.Extras = runs;
                    ball.Runs = 0;
                    innings.Legbyes += runs;
                    over.Extras = runs;
                    bowler.RunsConceded += runs;
                    break;
            }
            switch (ball.BoundaryType)
            {
                case BoundaryType.Four:
                    innings.NumberOfFours++;
                    batsmen.NumberOfFours++;
                    bowler.NumberOfFoursConceded++;
                    break;
                case BoundaryType.Six:
                    innings.NumberOfSixers++;
                    batsmen.NumberOfSixers++;
                    bowler.NumberOfSixersConceded++;
                    break;
            }

            if (isDismissal)
            {
                switch (disMissalType)
                {
                    case DisMissalType.Bowled:
                    case DisMissalType.Caught:
                    case DisMissalType.StumpOut:
                    case DisMissalType.HitWicket:
                    case DisMissalType.Lbw:
                        bowler.NumberOfWickets++;
                        break;
                }
                if (dismissedPlayer != null)
                {
                    batsmen.Dismissed = true;
                }
            }

            innings.NumberOfOversBowled = over.Number - 1 + "." + ball.BallNumber;

            CurrentOver().Balls.Add(ball);

            var striker = this.CurrentInnings().Striker;
            var nonStriker = this.CurrentInnings().NonStriker;
            if (IsOdd(ball.Runs))
            {
                this.CurrentInnings().Striker = nonStriker;
                this.CurrentInnings().NonStriker = striker;
            }
            if (isDismissal)
            {
                if (dismissedPlayer != null && dismissedPlayer.Id == striker.Id)
                {
                    CurrentInnings().Striker = null;
                }
                else
                {
                    CurrentInnings().NonStriker = null;
                }

            }

            var timelineAction = new TimelineAction
            {
                InningsNumber = innings.InningsNumber,
                OverNumber = over.Number,
                BallNumber = ball.BallNumber,
                BallAttemptNumber = ball.BallAttemptNumber,
                BallType = ball.BallType,
                RunsType = ball.RunsType,
                Runs = ball.Runs
            };
            if (batsmen != null) timelineAction.BatsmenId = batsmen.Id;
            if (bowler != null) { timelineAction.BowlerId = bowler.Id; bowler.BallsBowled++; }
            if (playerFielder != null) timelineAction.FielderId = playerFielder.Id;
            this.CurrentInnings().TimelineActions.Add(timelineAction);
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
        public void SetStrikerNonStrikerBatsmen(CricketPlayer selectdPlayer, bool isStriker)
        {
            var newBatsmen = new BattingTeamPlayer(selectdPlayer);
            this.CurrentInnings().BattingTeamPlayers.Add(newBatsmen);

            if (isStriker)
            {
                this.CurrentInnings().Striker = newBatsmen;
            }
            else
            {
                this.CurrentInnings().NonStriker = newBatsmen;
            }
        }

        public void SetBatsmenComingOn(CricketPlayer selectdPlayer)
        {
            var newBatsmen = new BattingTeamPlayer(selectdPlayer);
            this.CurrentInnings().BattingTeamPlayers.Add(newBatsmen);

            if (this.CurrentInnings().Striker == null)
            {
                this.CurrentInnings().Striker = newBatsmen;
            }
            else
            {
                this.CurrentInnings().NonStriker = newBatsmen;
            }
        }

        public static string AddOrdinal(int num)
        {
            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }

        public void SetMatchStatus(MatchStatus status)
        {
            this.MatchStatus = status;
        }
    }
}
