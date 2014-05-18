using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.GameService_Tests
{
    [TestClass]
    public class RecordResultTests
    {
        private Player _playerOne;
        private Player _playerTwo;
        private IGameService _gameService;
        private TestRoundRepository _roundRepository;

        [TestInitialize]
        public void TestInit()
        {
            _playerOne = new Player("Player 1", PlayerType.Computer) { Gesture = Gesture.Paper };
            _playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Rock };
            _roundRepository = new TestRoundRepository();
            _gameService = new GameService(_roundRepository);
        }

        [TestMethod]
        public void Winners_score_is_incremented()
        {
            // Arrange

            // Act
            _gameService.RecordResult(_playerOne, _playerTwo, _playerOne);

            // Assert
            Assert.AreEqual(1, _playerOne.CurrentScore);
        }

        [TestMethod]
        public void Losers_score_is_not_incremented()
        {
            // Arrange

            // Act
            _gameService.RecordResult(_playerOne, _playerTwo, _playerOne);

            // Assert
            Assert.AreEqual(0, _playerTwo.CurrentScore);
        }

        [TestMethod]
        public void Draw_means_no_one_scores()
        {
            // Arrange
            _playerTwo.Gesture = Gesture.Paper;

            // Act
            _gameService.RecordResult(_playerOne, _playerTwo, null);

            // Assert
            Assert.AreEqual(0, _playerOne.CurrentScore);
            Assert.AreEqual(0, _playerTwo.CurrentScore);
        }
        
        [TestMethod]
        public void Round_added_called()
        {
            // Arrange

            // Act
            _gameService.RecordResult(_playerOne, _playerTwo, _playerOne);

            // Assert
            Assert.IsTrue(_roundRepository.AddWasCalled);
        }

        [TestMethod]
        public void Round_data_added_is_correct()
        {
            // Arrange

            // Act
            _gameService.RecordResult(_playerOne, _playerTwo, _playerOne);

            // Assert
            Assert.AreEqual(1, _roundRepository.Round.Player1Score);
            Assert.AreEqual(0, _roundRepository.Round.Player2Score);
            Assert.AreEqual(Gesture.Paper, _roundRepository.Round.Player1Gesture);
            Assert.AreEqual(Gesture.Rock, _roundRepository.Round.Player2Gesture);
        }
    }
}
