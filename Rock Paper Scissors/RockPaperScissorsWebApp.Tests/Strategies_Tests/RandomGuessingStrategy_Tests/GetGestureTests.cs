using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Strategies;

namespace RockPaperScissorsWebApp.Tests.Strategies_Tests.RandomGuessingStrategy_Tests
{
    [TestClass]
    public class GetGestureTests
    {
        [TestMethod]
        public void Two_instances_of_random_strategy_dont_always_return_different_answers()
        {
            var results = new List<bool>();
            for (var i = 1; i <= 20; i++)
            {
                // Arrange
                var randomGuessingStrategy1 = new RandomGuessingStrategy(1);
                var randomGuessingStrategy2 = new RandomGuessingStrategy(1);

                // Act
                var gesture1 = randomGuessingStrategy1.GetGesture();
                var gesture2 = randomGuessingStrategy2.GetGesture();

                // Assert
                results.Add(gesture1 == gesture2);
            }
            Assert.IsFalse(results.All(r => r));
        }
    }
}
