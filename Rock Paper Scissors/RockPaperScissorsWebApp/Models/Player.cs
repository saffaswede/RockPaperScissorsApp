using RockPaperScissorsWebApp.Enums;

namespace RockPaperScissorsWebApp.Models
{
    public class Player
    {
        public Gesture Gesture;
        public readonly string Name;
        public int CurrentScore;
        public PlayerType PlayerType;

        public Player(string name, PlayerType playerType)
        {
            Name = name;
            PlayerType = playerType;
            CurrentScore = 0;
        }

    }
}