using RockPaperScissorsWebApp.Enums;

namespace RockPaperScissorsWebApp.Models
{
    public abstract class Strategy
    {
        protected Strategy(double weight)
        {
            Weighting = weight;
        }

        public abstract double GetProbability();

        public double GetProbabilityWithWeighting()
        {
            return GetProbability() * Weighting;
        }

        public abstract Gesture GetGesture();

        public double Weighting { get; private set; }
    }
}