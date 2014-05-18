using System.Collections.Generic;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Repositories;

namespace RockPaperScissorsWebApp.Tests
{
    public class TestRoundRepository : IRoundRepository
    {
        private readonly IEnumerable<Round> _rounds;

        public TestRoundRepository()
        {
            _rounds = new List<Round>();
            AddWasCalled = false;
            GetAllWasCalled = false;
            ClearWasCalled = false;
        }

        public bool GetAllWasCalled { get; set; }

        public void Add(Round round)
        {
            AddWasCalled = true;
            Round = round;
        }

        public Round Round { get; set; }

        public bool AddWasCalled { get; set; }

        public IEnumerable<Round> GetAll()
        {
            GetAllWasCalled = true;
            return _rounds;
        }

        public void Clear()
        {
            ClearWasCalled = true;
        }

        public bool ClearWasCalled { get; set; }
    }
}