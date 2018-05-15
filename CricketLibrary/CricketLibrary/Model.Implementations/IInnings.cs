namespace CricketLibrary.Model.Implementations
{
    public interface IInnings
    {
        void UndoBall();
        void StartOver(CricketPlayer bowler);
        void EndOver();
        void AddBall(BallType ballType, RunsType runsType, BoundaryType boundaryType, int runs, CricketPlayer bowler, CricketPlayer batsmen,
            bool isDismissal, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType);
        void SetStrikerNonStrikerBatsmen(CricketPlayer batsmen, bool isStriker);
        void SetBatsmenComingOn(CricketPlayer batsmenId);
    }
}
