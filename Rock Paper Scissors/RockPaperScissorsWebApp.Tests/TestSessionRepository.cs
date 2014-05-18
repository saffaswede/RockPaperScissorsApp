using System.Collections.Generic;
using RockPaperScissorsWebApp.Repositories;

namespace RockPaperScissorsWebApp.Tests
{
    public class TestSessionRepository<T> : IRepository<T>
    {
        private readonly IList<T> _items;

        public TestSessionRepository()
        {
            _items = new List<T>();
            AddWasCalled = false;
            GetAllWasCalled = false;
            ClearWasCalled = false;
            SaveWasCalled = false;
        }

        public bool GetAllWasCalled { get; set; }

        public void Add(T item)
        {
            AddWasCalled = true;
            Item = item;
            _items.Add(item);
        }

        public T Item { get; set; }

        public bool AddWasCalled { get; set; }

        public IEnumerable<T> GetAll()
        {
            GetAllWasCalled = true;
            return _items;
        }

        public void Save(IEnumerable<T> items)
        {
            SaveWasCalled = true;
        }

        public bool SaveWasCalled { get; set; }

        public void Clear()
        {
            ClearWasCalled = true;
        }

        public bool ClearWasCalled { get; set; }
    }
}