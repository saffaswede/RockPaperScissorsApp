using System.Collections.Generic;
using RockPaperScissorsWebApp.Enums;

namespace RockPaperScissorsWebApp.Models
{
    public class ScorecardViewModel
    {
        public string Player1Name { get; set; }
        public int Player1Score { get; set; }
        public Gesture Player1Gesture { get; set; }
        public string Player2Name { get; set; }
        public int Player2Score { get; set; }
        public Gesture Player2Gesture { get; set; }
        public IList<Round> History { get; set; }

        public ScorecardViewModel()
        {
            History = new List<Round>();
        }

    }
}