using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Controllers;
using RockPaperScissorsWebApp.Enums;

namespace RockPaperScissorsWebApp.Tests.Controllers.GameController_Tests
{
    [TestClass]
    public class GetHumanGesturesTests
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
        public void Calls_GameService_GetScorecard()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);
            
            // Act
            var result = controller.GetHumanGesture(Gesture.Rock) as ViewResult;

            // Assert
            Assert.IsTrue(_testGameService.GetScorecardWasCalled);
        }

        [TestMethod]
        public void Calls_PlayerService_GetPlayers()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.GetHumanGesture(Gesture.Rock) as ViewResult;

            // Assert
            Assert.IsTrue(_testPlayerService.GetPlayersWasCalled);
        }

        [TestMethod]
        public void Calls_PlayerService_GetComputerGesture()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.GetHumanGesture(Gesture.Rock) as ViewResult;

            // Assert
            Assert.IsTrue(_testPlayerService.GetComputerGestureWasCalled);
        }

        [TestMethod]
        public void Calls_PlayerService_SavePlayers()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.GetHumanGesture(Gesture.Rock) as ViewResult;

            // Assert
            Assert.IsTrue(_testPlayerService.SavePlayersWasCalled);
        }
    }
}
