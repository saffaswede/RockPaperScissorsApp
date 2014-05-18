using System.Collections.Generic;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Services
{
    public interface IGameService
    {
        Player CalculateWinner(Player playerOne, Player playerTwo);
        void RecordResult(Player playerOne, Player playerTwo, Player winner);
        IEnumerable<Round> GetScorecard();
        void Reset();
    }
}