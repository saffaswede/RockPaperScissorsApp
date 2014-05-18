using System.Collections.Generic;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Services
{
    public interface IPlayerService
    {
        IEnumerable<Player> CreateTwoComputerPlayers(string playerOneName, string playerTwoName);
        IEnumerable<Player> CreateOneComputerAndOneHumanPlayer(string playerOneName, string playerTwoName);
        Gesture GetComputerGesture(IList<Gesture> opponentGestures);
    }
}