using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.GameService_Tests
{
    [TestClass]
    public class CalculateWinnerTests
    {
        private TestSessionRepository<Round> _testRoundRepository;
        private GameService _game;

        [TestInitialize]
        public void TestInit()
        {
            _testRoundRepository = new TestSessionRepository<Round>();
            _game = new GameService(_testRoundRepository);
        }

        [TestMethod]
        public void Rock_plays_rock_is_a_draw()
        {
            // Arrange
            var playerOne = new Player("Player 1",PlayerType.Computer) { Gesture = Gesture.Rock };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Rock };
            
            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Paper_plays_paper_is_a_draw()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Paper };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Paper };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Scissors_plays_scissors_is_a_draw()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Scissors };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Rock_plays_paper_paper_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Rock };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Paper };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerTwo, actual);
        }

        [TestMethod]
        public void Paper_plays_rock_paper_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Paper };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Rock };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerOne, actual);
        }

        [TestMethod]
        public void Rock_plays_scisors_rock_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Rock };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Scissors };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerOne, actual);
        }

        [TestMethod]
        public void Scissors_plays_rock_rock_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Rock };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerTwo, actual);
        }

        [TestMethod]
        public void Paper_plays_scissors_scissors_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Paper };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Scissors };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerTwo, actual);
        }

        [TestMethod]
        public void Scissors_plays_paper_scissors_wins()
        {
            // Arrange
            var playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Scissors };
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Paper };

            // Act
            var actual = _game.CalculateWinner(playerOne, playerTwo);

            // Assert
            Assert.AreEqual(playerOne, actual);
        }
    }
}
