using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Strategies;

namespace RockPaperScissorsWebApp.Tests.Strategies_Tests.FrequencyAnalysisStrategy_Tests
{
    [TestClass]
    public class GetProbabilityTests
    {
        private const int Weight = 1;
        private IList<Gesture> _gestures;
        private GestureCollectionBuilder _gestureCollectionBuilder;
        private FrequencyAnalysisStrategy _frequencyAnalysisStrategy;

        [TestInitialize]
        public void TestInit()
        {
            _gestureCollectionBuilder = new GestureCollectionBuilder();
            _gestures = _gestureCollectionBuilder.AddPaper()
                .AddPaper()
                .AddPaper()
                .AddPaper()
                .AddRock()
                .AddScissors()
                .AddScissors()
                .AddScissors()
                .Build();
            _frequencyAnalysisStrategy = new FrequencyAnalysisStrategy(Weight, _gestures);
        }

        [TestMethod]
        public void If_paper_is_most_frequent_and_chosen_four_times_out_of_eight_then_probability_fifty_percent()
        {
            // Arrange

            // Act
            var actual = _frequencyAnalysisStrategy.GetProbability();

            // Assert
            Assert.AreEqual(0.5, actual);
        }

        [TestMethod]
        public void If_paper_and_rock_is_most_frequent_and_chosen_three_times_out_of_eight_then_probability_thirthyseven_percent()
        {
            // Arrange
            _gestures = _gestureCollectionBuilder.Clear()
                .AddPaper()
                .AddRock()
                .AddRock()
                .AddPaper()
                .AddRock()
                .AddPaper()
                .AddScissors()
                .AddScissors()
                .Build();
            _frequencyAnalysisStrategy.OpponentGestures = _gestures;

            // Act
            var actual = _frequencyAnalysisStrategy.GetProbability();

            // Assert
            Assert.AreEqual(0.375, actual);
        }
    }
}
