using System;

namespace CricketLibrary.Model
{
    public class PlayerRole
    {
        public int PlayerId { get; set; }
        public int TeamId { get; internal set; }
        public bool IsInSquad { get; set; }
        public PlayerRoleType RoleType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

   public enum PlayerRoleType
    {
        Player,
        Umpire
    }
}
