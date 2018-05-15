using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CricketLibrary.Model;

namespace CricketLibrary.Data
{
    public static class Players
    {
        public static List<Player> GetPlayers()
        {
            var player = new Player
            {
                Id = 1,
                Name = "Sathya",
            
            };
            player.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId=player.Id,
                StartDate=DateTime.Now,
                EndDate=DateTime.Now.AddYears(1)        
            };
            var player1 = new Player
            {
                Id = 2,
                Name = "Baz",             
            };
            player1.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player2 = new Player
            {
                Id = 3,
                Name = "Voke",

            };
            player2.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            var player3 = new Player
            {
                Id = 4,
                Name = "Simmo",

            };
            player3.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            var player4 = new Player
            {
                Id = 5,
                Name = "Rob",

            };
            player4.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player5 = new Player
            {
                Id = 6,
                Name = "Jamie",

            };
            player5.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player6 = new Player
            {
                Id = 7,
                Name = "Kel",

            };
            player6.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player7 = new Player
            {
                Id = 8,
                Name = "Commins",

            };
            player7.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player8 = new Player
            {
                Id = 9,
                Name = "Np",

            };
            player8.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player9 = new Player
            {
                Id = 10,
                Name = "Chris",

            };
            player9.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player10 = new Player
            {
                Id = 11,
                Name = "LLoyd",

            };
            player10.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player11 = new Player
            {
                Id = 12,
                Name = "Tobie",

            };
            player11.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player12 = new Player
            {
                Id = 13,
                Name = "Ross",

            };
            player12.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var player13 = new Player
            {
                Id = 14,
                Name = "Spencer",

            };
            player13.PlayerRole = new PlayerRole
            {
                TeamId = 10990,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            var aPlayer = new Player
            {
                Id = 1,
                Name = "Away Sathya",

            };
            aPlayer.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer1 = new Player
            {
                Id = 2,
                Name = "Away Baz",

            };
            aPlayer1.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer2 = new Player
            {
                Id = 3,
                Name = "Away Voke",

            };
            aPlayer2.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            var aPlayer3 = new Player
            {
                Id = 4,
                Name = "Away Simmo",

            };
            aPlayer3.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            var aPlayer4 = new Player
            {
                Id = 5,
                Name = "Away Rob",

            };
            aPlayer4.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer5 = new Player
            {
                Id = 6,
                Name = "Away Jamie",

            };
            aPlayer5.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer6 = new Player
            {
                Id = 7,
                Name = "Away Kel",

            };
            aPlayer6.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer7 = new Player
            {
                Id = 8,
                Name = "Away Commins",

            };
            aPlayer7.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer8 = new Player
            {
                Id = 9,
                Name = "Away Np",

            };
            aPlayer8.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer9 = new Player
            {
                Id = 10,
                Name = "Away Chris",

            };
            aPlayer9.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer10 = new Player
            {
                Id = 11,
                Name = "Away LLoyd",

            };
            aPlayer10.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer11 = new Player
            {
                Id = 12,
                Name = "Away Tobie",

            };
            aPlayer11.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer12 = new Player
            {
                Id = 13,
                Name = "Away Ross",

            };
            aPlayer12.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };
            var aPlayer13 = new Player
            {
                Id = 14,
                Name = "Away Spencer",

            };
            aPlayer13.PlayerRole = new PlayerRole
            {
                TeamId = 34590,
                PlayerId = player.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            var homePlayer = new List<Player> {player, player1, player2, player3, player4, player5, aPlayer, aPlayer1, aPlayer2, aPlayer3, aPlayer4, aPlayer5 };
            //, player6, player7, player8, player9, player10, player11, player12, player13 };
            var awayPlayer = new List<Player> {aPlayer, aPlayer1, aPlayer2, aPlayer3, aPlayer4, aPlayer5};
            //, aPlayer6, aPlayer7, aPlayer8, aPlayer9, aPlayer1, aPlayer11, aPlayer12, aPlayer13 };
            return homePlayer;
        }
    }
}

