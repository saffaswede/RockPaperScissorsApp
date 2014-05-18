using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Controllers;

namespace RockPaperScissorsWebApp.Tests.Controllers.GameController_Tests
{
    [TestClass]
    public class ScorecardTests
    {
        private TestGameService _testGameService;
        private TestPlayerService _testPlayerService;

        [TestInitialize]
        public void TestInit()
        {
            _testGameService = new TestGameService();
            _testPlayerService = new TestPlayerService();
        }
        
        [TestMethod]
        public void Calls_PlayerService_GetPlayers()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.Scorecard() as ViewResult;

            // Assert
            Assert.IsTrue(_testPlayerService.GetPlayersWasCalled);
        }

        [TestMethod]
        public void Calls_GameService_CalculateWinner()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.Scorecard() as ViewResult;

            // Assert
            Assert.IsTrue(_testGameService.CalculateWinnerWasCalled);
        }

        [TestMethod]
        public void Calls_GameService_RecordResult()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.Scorecard() as ViewResult;

            // Assert
            Assert.IsTrue(_testGameService.RecordResultWasCalled);
        }

        [TestMethod]
        public void Calls_GameService_GetScorecard()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.Scorecard() as ViewResult;

            // Assert
            Assert.IsTrue(_testGameService.GetScorecardWasCalled);
        }
    }
}
