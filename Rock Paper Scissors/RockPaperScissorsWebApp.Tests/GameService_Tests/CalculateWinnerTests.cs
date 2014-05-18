using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.GameService_Tests
{
    [TestClass]
    public class CalculateWinnerTests
    {
        [TestMethod]
        public void Rock_plays_rock_is_a_draw()
        {
            // Arrange
            var playerOne = new Player("Player 1",PlayerType.Computer) { Gesture = Gesture.Rock };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Rock };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Paper_plays_paper_is_a_draw()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Paper };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Paper };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Scissors_plays_scissors_is_a_draw()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Rock_plays_paper_paper_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Rock };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Paper };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerTwo, actual);
        }

        [TestMethod]
        public void Paper_plays_rock_paper_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Paper };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Rock };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerOne, actual);
        }

        [TestMethod]
        public void Rock_plays_scisors_rock_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Rock };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerOne, actual);
        }

        [TestMethod]
        public void Scissors_plays_rock_rock_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Rock };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerTwo, actual);
        }

        [TestMethod]
        public void Paper_plays_scissors_scissors_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Paper };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerTwo, actual);
        }

        [TestMethod]
        public void Scissors_plays_paper_scissors_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Paper };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            var actual = game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerOne, actual);
        }
    }
}
