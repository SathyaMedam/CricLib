using System;

namespace CricketLibrary.Model
{
    public class Season
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name => StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString();
    }
}
