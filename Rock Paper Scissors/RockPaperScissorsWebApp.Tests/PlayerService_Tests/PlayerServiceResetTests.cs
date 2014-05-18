using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.PlayerService_Tests
{
    [TestClass]
    public class PlayerServiceResetTests
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
        public void Round_repository_Reset_WasCalled()
        {
            // Arrange

            // Act
            _playerService.Reset();

            // Assert
            Assert.IsTrue(_testPlayerRepository.ClearWasCalled);
        }
    }
}
