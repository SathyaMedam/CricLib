namespace CricketLibrary.Model
{
    public class CricketMatchProperties
    {
        public FormatType FormatType { get; set; }
        public int NumberOfOvers { get; set; }
        public int NumberOfInnings { get; set; }
        public int WideValue { get; set; }
        public int NoBallValue { get; set; }
        public int NumberOfPlayersPerTeam { get; set; }

        public CricketMatchProperties()
        {
            FormatType = FormatType.ODI;
        }
    }
}
