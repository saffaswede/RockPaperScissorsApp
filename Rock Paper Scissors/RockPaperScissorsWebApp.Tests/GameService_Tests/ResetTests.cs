using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.GameService_Tests
{
    [TestClass]
    public class ResetTests
    {
        private IGameService _gameService;
        private TestSessionRepository<Round> _testRoundRepository;

        [TestInitialize]
        public void TestInit()
        {
            _testRoundRepository = new TestSessionRepository<Round>();
            _gameService = new GameService(_testRoundRepository);
        }

        [TestMethod]
        public void Round_repository_Reset_WasCalled()
        {
            // Arrange

            // Act
            _gameService.Reset();

            // Assert
            Assert.IsTrue(_testRoundRepository.ClearWasCalled);
        }
    }
}
