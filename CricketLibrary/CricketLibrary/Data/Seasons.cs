using System;
using System.Collections.Generic;
using CricketLibrary.Model;

namespace CricketLibrary.Data
{
    public static class Seasons
    {
        public static List<Season> GetSeasons()
        {

            var season1 = new Season { Id = 99990, StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(6)};
            var season2 = new Season { Id = 88990, StartDate = DateTime.Today.AddYears(-1) };
            season2.EndDate = season2.StartDate.AddMonths(6);

            return new List<Season> { season1, season2 };
        }
    }
}
