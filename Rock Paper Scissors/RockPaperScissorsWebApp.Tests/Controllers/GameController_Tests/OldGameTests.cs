using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Controllers;

namespace RockPaperScissorsWebApp.Tests.Controllers.GameController_Tests
{
    [TestClass]
    public class OldGameTests
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
        public void Calls_PlayersService_GetPlayers()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);
            
            // Act
            controller.OldGame();

            // Assert
            Assert.IsTrue(_testPlayerService.GetPlayersWasCalled);
        }
    }
}
