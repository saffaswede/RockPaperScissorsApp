using System.Collections.Generic;
using System.Linq;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Factories;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IStrategyFactory _strategyFactory;

        public PlayerService(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public Gesture GetComputerGesture(IList<Gesture> opponentGestures)
        {
            // Random Guessing Strategy
            // Frequency Analysis Strategy - Most frequently played move
            // Turn Matching Strategy - Match pattern for last few moves

            var bestStrategy = _strategyFactory.CreateStrategies(opponentGestures).OrderByDescending(s => s.GetProbabilityWithWeighting()).First();
            return bestStrategy.GetGesture();
        }

        public IEnumerable<Player> CreateOneComputerAndOneHumanPlayer(string playerOneName, string playerTwoName)
        {
            return new List<Player>
            {
                new Player(playerOneName, PlayerType.Human),
                new Player(playerTwoName, PlayerType.Computer)
            };
        }

        public IEnumerable<Player> CreateTwoComputerPlayers(string playerOneName, string playerTwoName)
        {
            return new List<Player>
            {
                new Player(playerOneName, PlayerType.Computer),
                new Player(playerTwoName, PlayerType.Computer)
            };
        }
    }
}
