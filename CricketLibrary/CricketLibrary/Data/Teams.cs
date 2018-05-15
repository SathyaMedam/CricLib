using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CricketLibrary.Model;

namespace CricketLibrary.Data
{
    public static class Teams
    {
        public static List<Team> GetTeams()
        {

            var team1 = new Team { Id = 10990, Name = "India" };
            var team2 = new Team {  Id = 28990, Name = "England" };
            var team3 = new Team {  Id = 34590, Name = "Australia" };
            var team4 = new Team {  Id = 67890, Name = "South Africa" };
            return new List<Team> { team1, team2, team3, team4 };
        }
    }
}
