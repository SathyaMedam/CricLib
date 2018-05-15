using System.Collections.Generic;
using Newtonsoft.Json;

namespace CricketLibrary.Model
{
    public class Over
    {

        public int Number { get; set; }
        public OverStatus OverStauts { get; set; }
        public int BowlerId { get; set; }
        //[JsonIgnore]
        //public CricketPlayer Bowler { get; set; }  
        public int Runs { get; set; }
        public int Extras { get; set; }
        public List<Ball> Balls { get; set; }
      
        public Over()
        {
            Balls = new List<Ball>();

        }
    }


    public enum OverStatus
    {
        OverNotStarted,
        OverInProgress,
        OverFinished
    }
}
