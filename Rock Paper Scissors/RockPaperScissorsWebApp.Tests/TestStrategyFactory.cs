using System.Collections.Generic;
using System.Linq;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Factories;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Tests
{
    public class TestStrategyFactory : IStrategyFactory
    {
        private readonly IEnumerable<Strategy> _strategies;

        public TestStrategyFactory(IEnumerable<Strategy> strategies)
        {
            _strategies = strategies;
        }

        public IEnumerable<Strategy> CreateStrategies(IList<Gesture> opponentGestures)
        {
            return _strategies.ToList();
        }
    }
}