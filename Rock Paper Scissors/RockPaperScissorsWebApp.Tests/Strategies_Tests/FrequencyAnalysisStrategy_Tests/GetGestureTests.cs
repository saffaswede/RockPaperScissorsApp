using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Strategies;

namespace RockPaperScissorsWebApp.Tests.Strategies_Tests.FrequencyAnalysisStrategy_Tests
{
    [TestClass]
    public class GetGestureTests
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
        public void If_paper_is_most_frequent_and_chosen_four_times_out_of_eight_then_scissors_chosen()
        {
            // Arrange

            // Act
            var actual = _frequencyAnalysisStrategy.GetGesture();

            // Assert
            Assert.AreEqual(Gesture.Scissors, actual);
        }

        [TestMethod]
        public void If_scissors_is_most_frequent_and_chosen_five_times_out_of_eight_then_rock_chosen()
        {
            // Arrange
            _gestures = _gestureCollectionBuilder.Clear()
                .AddPaper()
                .AddScissors()
                .AddScissors()
                .AddPaper()
                .AddRock()
                .AddScissors()
                .AddScissors()
                .AddScissors()
                .Build();
            _frequencyAnalysisStrategy.OpponentGestures = _gestures;

            // Act
            var actual = _frequencyAnalysisStrategy.GetGesture();

            // Assert
            Assert.AreEqual(Gesture.Rock, actual);
        }

        [TestMethod]
        public void If_rock_is_most_frequent_and_chosen_six_times_out_of_eight_then_paper_chosen()
        {
            // Arrange
            _gestures = _gestureCollectionBuilder.Clear()
                .AddRock()
                .AddRock()
                .AddRock()
                .AddRock()
                .AddRock()
                .AddRock()
                .AddScissors()
                .AddScissors()
                .Build();
            _frequencyAnalysisStrategy.OpponentGestures = _gestures;

            // Act
            var actual = _frequencyAnalysisStrategy.GetGesture();

            // Assert
            Assert.AreEqual(Gesture.Paper, actual);
        }

        [TestMethod]
        public void If_rock_and_scissors_are_most_frequent_and_chosen_three_times_out_of_eight_then_paper_not_chosen()
        {
            // Arrange
            _gestures = _gestureCollectionBuilder.Clear()
                .AddRock()
                .AddRock()
                .AddRock()
                .AddPaper()
                .AddPaper()
                .AddScissors()
                .AddScissors()
                .AddScissors()
                .Build();
            _frequencyAnalysisStrategy.OpponentGestures = _gestures;

            for (var i = 1; i <= 20; i++)
            {
                // Act
                var actual = _frequencyAnalysisStrategy.GetGesture();

                // Assert
                Assert.AreNotEqual(Gesture.Scissors, actual);
            }
        }
    }
}
