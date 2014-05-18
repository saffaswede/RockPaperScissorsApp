using System.Collections.Generic;

namespace RockPaperScissorsWebApp.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        void Save(IEnumerable<T> items);
        void Clear();
    }
}