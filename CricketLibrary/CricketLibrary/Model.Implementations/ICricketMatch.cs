using System.Collections.Generic;

namespace CricketLibrary.Model.Implementations
{
    public interface ICricketMatch
    {
        //CricketMatch GetMatch(int matchId);
        //void AddPlayersToTeam(List<int> selectdPlayerIds, bool isHomeTeam);
        void EndMatch();
        void CoinToss(int teamWonId, TossDecisionType decisionType);
        void EndInnings();
        void StartInnings();
    }
}
