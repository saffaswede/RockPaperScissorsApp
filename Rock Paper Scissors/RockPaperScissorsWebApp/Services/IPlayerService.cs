using System.Collections.Generic;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Services
{
    public interface IPlayerService
    {
        void CreateTwoComputerPlayers(string playerOneName, string playerTwoName);
        void CreateOneComputerAndOneHumanPlayer(string playerOneName, string playerTwoName);
        Gesture GetComputerGesture(IList<Gesture> opponentGestures);
        IEnumerable<Player> GetPlayers();
        void Reset();
        void SavePlayers(IEnumerable<Player> players);
    }
}