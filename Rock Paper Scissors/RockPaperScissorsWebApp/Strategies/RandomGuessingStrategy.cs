using System;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Strategies
{
    public class RandomGuessingStrategy : Strategy
    {
        private const double Probability = 0.33;

        public RandomGuessingStrategy(double weight) : base(weight)
        {}

        public override double GetProbability()
        {
            return Probability;
        }

        public override Gesture GetGesture()
        {
            return (Gesture)RandomNumberGenerator.GetRandomNumber(Enum.GetValues(typeof(Gesture)).Length);
        }
    }
}