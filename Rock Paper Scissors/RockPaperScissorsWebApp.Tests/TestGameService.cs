using System.Collections.Generic;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests
{
    public class TestGameService : IGameService
    {
        public TestGameService()
        {
            CalculateWinnerWasCalled = false;
            RecordResultWasCalled = false;
            GetScorecardWasCalled = false;
            ResetWasCalled = false;
        }

        public bool RecordResultWasCalled { get; set; }
        
        public Player CalculateWinner(Player playerOne, Player playerTwo)
        {
            CalculateWinnerWasCalled = true;
            return playerOne;
        }

        public bool CalculateWinnerWasCalled { get; set; }

        public void RecordResult(Player playerOne, Player playerTwo, Player winner)
        {
            RecordResultWasCalled = true;
        }

        public IEnumerable<Round> GetScorecard()
        {
            GetScorecardWasCalled = true;
            return new List<Round> ();
        }

        public bool GetScorecardWasCalled { get; set; }

        public void Reset()
        {
            ResetWasCalled = true;
        }

        public bool ResetWasCalled { get; set; }
    }
}
