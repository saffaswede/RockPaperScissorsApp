using System;
using System.Collections.Generic;
using System.Linq;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Repositories;

namespace RockPaperScissorsWebApp.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Round> _roundRepository;

        public GameService(IRepository<Round> roundRepository)
        {
            _roundRepository = roundRepository;
        }

        public Player CalculateWinner(Player playerOne, Player playerTwo)
        {
            if (playerOne == null) throw new ArgumentNullException("playerOne");
            if (playerTwo == null) throw new ArgumentNullException("playerTwo");

            if (playerOne.Gesture == playerTwo.Gesture) return null;
            return ((int)playerOne.Gesture + 1) % 3 == (int)playerTwo.Gesture
                ? playerTwo
                : playerOne;
        }

        public void RecordResult(Player playerOne, Player playerTwo, Player winner)
        {
            if (winner != null)
            {
                winner.CurrentScore += 1;
            }

            var roundNumber = _roundRepository.GetAll().Count() + 1;

            var round = new Round
            {
                RoundNumber = roundNumber,
                Player1Gesture = playerOne.Gesture,
                Player2Gesture = playerTwo.Gesture,
                Player1Score = playerOne.CurrentScore,
                Player2Score = playerTwo.CurrentScore
            };

            _roundRepository.Add(round);
        }

        public IEnumerable<Round> GetScorecard()
        {
            return _roundRepository.GetAll();
        }

        public void Reset()
        {
            _roundRepository.Clear();
        }
    }
}