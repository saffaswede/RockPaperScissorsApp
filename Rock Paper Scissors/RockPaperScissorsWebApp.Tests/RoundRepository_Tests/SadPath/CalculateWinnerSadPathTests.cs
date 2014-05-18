using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Tests.RoundRepository_Tests.SadPath
{
    [TestClass]
    public class CalculateWinnerSadPathTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Player_one_is_null_throws_exception()
        {
            // Arrange
            var playerTwo = new Player("Player 2", PlayerType.Computer) { Gesture = Gesture.Paper };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            game.CalculateWinner(null, playerTwo);
            
            // Assert
            // Expect ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Player_two_is_null_throws_exception()
        {
            // Arrange
            var playerOne = new Player("Player 1" , PlayerType.Computer) { Gesture = Gesture.Paper };
            var testRoundRepository = new TestRoundRepository();
            var game = new GameService(testRoundRepository);

            // Act
            game.CalculateWinner(playerOne, null);

            // Assert
            // Expect ArgumentNullException
        }
    }
}