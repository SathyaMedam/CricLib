using System;

namespace CricketLibrary.Model
{
    public class BattingScoreCard
    {
        public int Runs { get; set; }
        public int BallsFaced { get; set; }
        public DateTime TimeAtCrease { get; set; }
        public int NumberOfDotBalls { get; set; }
        public int NumberOfFours { get; set; }
        public int NumberOfSixers { get; set; }
        public int TotalRuns => Runs + (NumberOfFours * 4) + (NumberOfSixers * 6);
        public double StrikeRate
        {
            get
            {
                if (BallsFaced>0)
                {
                    return (TotalRuns* 100 )/ BallsFaced ;
                }

                return 0.0;
            }
        }
    }
}
