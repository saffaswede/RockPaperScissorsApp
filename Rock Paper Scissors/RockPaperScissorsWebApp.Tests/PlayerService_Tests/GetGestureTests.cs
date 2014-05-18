using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Factories;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.PlayerService_Tests
{
    [TestClass]
    public class GetComputerGestureTests
    {
        private IList<Gesture> _oppenentGestures;

        [TestInitialize]
        public void TestInit()
        {
            _oppenentGestures = new List<Gesture>();
        }

        [TestMethod]
        public void Strategy_with_highest_probability_and_weighting_is_chosen_heigh_weighting()
        {
            // Arrange
            var strategies = new List<TestStrategy>
            {
                new TestStrategy(0.3) {Probability = 0.5},
                new TestStrategy(0.3) {Probability = 0.5},
                new TestStrategy(1) {Probability = 0.5}
            };
            IStrategyFactory testStrategyFactory = new TestStrategyFactory(strategies);
            var playerService = new PlayerService(testStrategyFactory);

            // Act
            playerService.GetComputerGesture(_oppenentGestures);

            // Assert
            Assert.IsTrue(strategies.Last().GetGestureCalled);
        }

        [TestMethod]
        public void Strategy_with_highest_probability_and_weighting_is_chosen_heigh_probability()
        {
            // Arrange
            var strategies = new List<TestStrategy>
            {
                new TestStrategy(0.3) {Probability = 1},
                new TestStrategy(0.3) {Probability = 0.75},
                new TestStrategy(0.3) {Probability = 0.5}
            };
            IStrategyFactory testStrategyFactory = new TestStrategyFactory(strategies);
            var playerService = new PlayerService(testStrategyFactory);

            // Act
            playerService.GetComputerGesture(_oppenentGestures);

            // Assert
            Assert.IsTrue(strategies.First().GetGestureCalled);
        }
    }
}
