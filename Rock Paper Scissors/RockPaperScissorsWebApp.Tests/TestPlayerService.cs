using System.Collections.Generic;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests
{
    public class TestPlayerService :IPlayerService
    {
        public TestPlayerService()
        {
            CreateTwoComputerPlayersWasCalled = false;
            CreateOneComputerAndOneHumanPlayerWasCalled = false;
            GetComputerGestureWasCalled = false;
            GetPlayersWasCalled = false;
            ResetWasCalled = false;
            SavePlayersWasCalled = false;
        }

        public void CreateTwoComputerPlayers(string playerOneName, string playerTwoName)
        {
            CreateTwoComputerPlayersWasCalled = true;
        }

        public bool CreateTwoComputerPlayersWasCalled { get; set; }

        public void CreateOneComputerAndOneHumanPlayer(string playerOneName, string playerTwoName)
        {
            CreateOneComputerAndOneHumanPlayerWasCalled = true;
        }

        public bool CreateOneComputerAndOneHumanPlayerWasCalled { get; set; }

        public Gesture GetComputerGesture(IList<Gesture> opponentGestures)
        {
            GetComputerGestureWasCalled = true;
            return Gesture.Paper;
        }

        public bool GetComputerGestureWasCalled { get; set; }

        public IEnumerable<Player> GetPlayers()
        {
            GetPlayersWasCalled = true;
            return new List<Player> { new Player("Player1",PlayerType.Human), new Player("Player2", PlayerType.Computer)};
        }

        public bool GetPlayersWasCalled { get; set; }

        public void Reset()
        {
            ResetWasCalled = true;
        }

        public bool ResetWasCalled { get; set; }

        public void SavePlayers(IEnumerable<Player> players)
        {
            SavePlayersWasCalled = true;
        }

        public bool SavePlayersWasCalled { get; set; }
    }
}
