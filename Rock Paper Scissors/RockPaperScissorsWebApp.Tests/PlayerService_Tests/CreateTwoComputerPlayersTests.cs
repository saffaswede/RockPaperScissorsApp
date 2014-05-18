using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.PlayerService_Tests
{
    [TestClass]
    public class CreateTwoComputerPlayersTests
    {
        private IPlayerService _playerService;
        private TestSessionRepository<Player> _testPlayerRepository;
        private TestStrategyFactory _testStrategyFactory;

        [TestInitialize]
        public void TestInit()
        {
            _testPlayerRepository = new TestSessionRepository<Player>();
            _testStrategyFactory = new TestStrategyFactory(new List<Strategy>());
            _playerService = new PlayerService(_testStrategyFactory, _testPlayerRepository);
        }

        [TestMethod]
        public void No_human_player_was_made()
        {
            // Arrange

            // Act
            _playerService.CreateTwoComputerPlayers("Computer1", "Computer2");

            // Assert
            Assert.IsFalse(_testPlayerRepository.GetAll().Any(i => i.PlayerType == PlayerType.Human));
        }

        [TestMethod]
        public void Two_computer_players_were_made()
        {
            // Arrange

            // Act
            _playerService.CreateTwoComputerPlayers("Computer1", "Computer2");

            // Assert
            Assert.AreEqual(2, _testPlayerRepository.GetAll().Count(i => i.PlayerType == PlayerType.Computer));
        }

        [TestMethod]
        public void Computer1_name_was_saved()
        {
            // Arrange

            // Act
            const string playerOneName = "Computer1";
            _playerService.CreateTwoComputerPlayers(playerOneName, "Computer2");

            // Assert
            var actual = _testPlayerRepository.GetAll().First();
            Assert.AreEqual(playerOneName, actual.Name);
        }

        [TestMethod]
        public void Computer2_name_was_saved()
        {
            // Arrange

            // Act
            const string playerTwoName = "Computer2";
            _playerService.CreateTwoComputerPlayers("Computer1", playerTwoName);

            // Assert
            var actual = _testPlayerRepository.GetAll().Last();
            Assert.AreEqual(playerTwoName, actual.Name);
        }
    }
}
