using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.GameService_Tests
{
    [TestClass]
    public class GetScorecardTests
    {
        private GameService _gameService;
        private TestRoundRepository _testRoundRepository;

        [TestInitialize]
        public void TestInit()
        {
            _testRoundRepository = new TestRoundRepository();
            _gameService = new GameService( _testRoundRepository);
        }
        
        [TestMethod]
        public void Round_repository_GetAllWasCalled()
        {
            // Arrange
            
            // Act
            _gameService.GetScorecard();

            // Assert
            Assert.IsTrue(_testRoundRepository.GetAllWasCalled);
        }
    }
}
