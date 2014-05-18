using RockPaperScissorsWebApp.Enums;

namespace RockPaperScissorsWebApp.Models
{
    public class Round
    {
        public Gesture Player1Gesture { get; set; }
        public Gesture Player2Gesture { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int RoundNumber { get; set; }
    }
}