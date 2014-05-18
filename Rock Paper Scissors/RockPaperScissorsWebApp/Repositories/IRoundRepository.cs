using System.Collections.Generic;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Repositories
{
    public interface IRoundRepository
    {
        void Add(Round round);
        IEnumerable<Round> GetAll();
        void Clear();
    }
}