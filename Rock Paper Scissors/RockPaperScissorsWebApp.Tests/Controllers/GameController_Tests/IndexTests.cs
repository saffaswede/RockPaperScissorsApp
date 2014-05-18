using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Controllers;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.Controllers.GameController_Tests
{
    [TestClass]
    public class IndexTests
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
        public void Calls_GameService_Reset()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);
            
            // Act
            controller.Index();

            // Assert
            Assert.IsTrue(_testGameService.ResetWasCalled);
        }

        [TestMethod]
        public void Calls_PlayerService_Reset()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            controller.Index();

            // Assert
            Assert.IsTrue(_testPlayerService.ResetWasCalled);
        }
    }
}
