using System.Collections.Generic;
using System.Collections.ObjectModel;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Strategies;

namespace RockPaperScissorsWebApp.Factories
{
    public class StrategyFactory : IStrategyFactory
    {
        private const int RandomGuessWeighting = 1;
        private const int FrequencyAnalysisWeighting = 2;

        public IEnumerable<Strategy> CreateStrategies(IList<Gesture> opponentGestures)
        {
            var strategies = new Collection<Strategy>
            {
                new RandomGuessingStrategy(RandomGuessWeighting),
                new FrequencyAnalysisStrategy(FrequencyAnalysisWeighting, opponentGestures)
            };

            return strategies;
        }
    }
}