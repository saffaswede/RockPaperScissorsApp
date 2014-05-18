using System.Collections.Generic;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Factories
{
    public interface IStrategyFactory
    {
        IEnumerable<Strategy> CreateStrategies(IList<Gesture> opponentGestures);
    }
}