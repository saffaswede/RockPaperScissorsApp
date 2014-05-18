using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Tests
{
    public class TestStrategy : Strategy
    {
        public TestStrategy(double weight) : base(weight)
        {
            GetGestureCalled = false;
        }

        public override double GetProbability()
        {
            return Probability;
        }

        public double Probability { get; set; }

        public override Gesture GetGesture()
        {
            GetGestureCalled = true;
            return Gesture.Paper;
        }

        public bool GetGestureCalled { get; set; }
    }
}