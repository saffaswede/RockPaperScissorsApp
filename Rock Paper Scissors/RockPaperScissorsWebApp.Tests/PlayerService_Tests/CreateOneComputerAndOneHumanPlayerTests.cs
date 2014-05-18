using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.PlayerService_Tests
{
    [TestClass]
    public class CreateOneComputerAndOneHumanPlayerTests
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
        public void A_human_player_was_made()
        {
            // Arrange
            
            // Act
            _playerService.CreateOneComputerAndOneHumanPlayer("Human", "Computer");

            // Assert
            Assert.IsTrue(_testPlayerRepository.GetAll().Any(i => i.PlayerType == PlayerType.Human));
        }

        [TestMethod]
        public void A_computer_player_was_made()
        {
            // Arrange

            // Act
            _playerService.CreateOneComputerAndOneHumanPlayer("Human", "Computer");

            // Assert
            Assert.IsTrue(_testPlayerRepository.GetAll().Any(i => i.PlayerType == PlayerType.Computer));
        }

        [TestMethod]
        public void Humans_name_was_saved()
        {
            // Arrange

            // Act
            const string playerOneName = "Human";
            _playerService.CreateOneComputerAndOneHumanPlayer(playerOneName, "Computer");

            // Assert
            var actual = _testPlayerRepository.GetAll().Single(i => i.PlayerType == PlayerType.Human);
            Assert.AreEqual(playerOneName,actual.Name);
        }

        [TestMethod]
        public void Computers_name_was_saved()
        {
            // Arrange

            // Act
            const string playerTwoName = "Computer";
            _playerService.CreateOneComputerAndOneHumanPlayer("Human", playerTwoName);

            // Assert
            var actual = _testPlayerRepository.GetAll().Single(i => i.PlayerType == PlayerType.Computer);
            Assert.AreEqual(playerTwoName, actual.Name);
        }
    }
}
