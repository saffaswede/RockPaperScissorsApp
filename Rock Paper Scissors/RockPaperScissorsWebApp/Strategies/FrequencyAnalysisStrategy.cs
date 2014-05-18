using System.Collections.Generic;
using System.Linq;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Strategies
{
    public class FrequencyAnalysisStrategy : Strategy
    {
        public IList<Gesture> OpponentGestures { get; set; }

        public FrequencyAnalysisStrategy(double weight, IList<Gesture> opponentGestures) : base(weight)
        {
            OpponentGestures = opponentGestures;
        }

        public override double GetProbability()
        {
            if (OpponentGestures == null || OpponentGestures.Count == 0)
            {
                return 0;
            }
            var mostFrequentGesture = GetMostFrequentGestureCount();

            return (double)mostFrequentGesture / OpponentGestures.Count;
        }

        private int GetMostFrequentGestureCount()
        {
            var counts = from r in OpponentGestures
                group r by r
                into g
                orderby g.Count() descending
                select g.Count();

            return counts.First();
        }

        private IEnumerable<Gesture> GetMostFrequentGestures()
        {
            var turns = (from r in OpponentGestures
                group r by r
                into g
                select new { Gesture = g.Key, Count = g.Count()}).ToList();

            var max = turns.Max(t => t.Count);

            return turns.Where(t => t.Count == max).Select(m => m.Gesture);
        }

        public override Gesture GetGesture()
        {
            var mostFrequentGestures = GetMostFrequentGestures().ToList();
            var indexOfMostFrequentGestureChosen = (RandomNumberGenerator.GetRandomNumber(mostFrequentGestures.Count()));
            var mostFrequentGestureChosen = mostFrequentGestures[indexOfMostFrequentGestureChosen];
            return (Gesture)(((int)mostFrequentGestureChosen + 1) % 3);
        }
    }
}