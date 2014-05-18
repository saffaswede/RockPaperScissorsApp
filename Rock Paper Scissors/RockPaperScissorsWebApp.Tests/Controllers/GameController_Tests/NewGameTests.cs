using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Controllers;
using RockPaperScissorsWebApp.Enums;

namespace RockPaperScissorsWebApp.Tests.Controllers.GameController_Tests
{
    [TestClass]
    public class NewGameTests
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
        public void Calls_CreateOneComputerAndOneHumanPlayer_when_human_vs_computer()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);
            
            // Act
            var result = controller.NewGame(GameType.HumanVsComputer) as ViewResult;

            // Assert
            Assert.IsTrue(_testPlayerService.CreateOneComputerAndOneHumanPlayerWasCalled);
        }

        [TestMethod]
        public void Calls_CreateTwoComputerPlayers_when_computer_vs_computer()
        {
            // Arrange
            var controller = new GameController(_testGameService, _testPlayerService);

            // Act
            var result = controller.NewGame(GameType.ComputerVsComputer) as ViewResult;

            // Assert
            Assert.IsTrue(_testPlayerService.CreateTwoComputerPlayersWasCalled);
        }
    }
}
