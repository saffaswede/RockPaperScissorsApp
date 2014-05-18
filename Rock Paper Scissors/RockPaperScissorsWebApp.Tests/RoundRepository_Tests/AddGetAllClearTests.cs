using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Repositories;

namespace RockPaperScissorsWebApp.Tests.RoundRepository_Tests
{
    [TestClass]
    public class AddGetAllClearTests
    {
        private RoundRepository _roundRepository;

        [TestInitialize]
        public void TestInit()
        {
   
            _roundRepository = new RoundRepository();

        }

        [TestMethod]
        public void Records_for_each_entry_are_written()
        {
            // Arrange
            var round = new Round();
            _roundRepository.Add(round);
            _roundRepository.Add(round);

            // Act
            var scorecard = _roundRepository.GetAll();

            // Assert
            Assert.AreEqual(2, scorecard.Count());
        }

        [TestMethod]
        public void Clear_removes_all_entries()
        {
            // Arrange
            var round = new Round();
            _roundRepository.Add(round);
            _roundRepository.Add(round);

            // Act
            _roundRepository.Clear();

            // Assert
            var scorecard = _roundRepository.GetAll();
            Assert.AreEqual(0, scorecard.Count());
        }
    }
}
