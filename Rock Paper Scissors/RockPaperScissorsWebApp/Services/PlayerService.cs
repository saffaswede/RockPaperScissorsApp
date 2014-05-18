using System.Collections.Generic;
using System.Linq;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Factories;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Repositories;

namespace RockPaperScissorsWebApp.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IStrategyFactory _strategyFactory;
        private readonly IRepository<Player> _playerRepository;

        public PlayerService(IStrategyFactory strategyFactory, IRepository<Player> playerRepository)
        {
            _strategyFactory = strategyFactory;
            _playerRepository = playerRepository;
        }

        public Gesture GetComputerGesture(IList<Gesture> opponentGestures)
        {
            // Random Guessing Strategy
            // Frequency Analysis Strategy - Most frequently played move
            // Turn Matching Strategy - Match pattern for last few moves

            var bestStrategy = _strategyFactory.CreateStrategies(opponentGestures).OrderByDescending(s => s.GetProbabilityWithWeighting()).First();
            return bestStrategy.GetGesture();
        }

        public void CreateOneComputerAndOneHumanPlayer(string playerOneName, string playerTwoName)
        {
            _playerRepository.Add(new Player(playerOneName, PlayerType.Human));
            _playerRepository.Add(new Player(playerTwoName, PlayerType.Computer));
        }

        public void CreateTwoComputerPlayers(string playerOneName, string playerTwoName)
        {
            _playerRepository.Add(new Player(playerOneName, PlayerType.Computer));
            _playerRepository.Add(new Player(playerTwoName, PlayerType.Computer));
        }

        public void SavePlayers(IEnumerable<Player> players)
        {
            _playerRepository.Save(players);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _playerRepository.GetAll();
        }

        public void Reset()
        {
            _playerRepository.Clear();
        }
    }
}
