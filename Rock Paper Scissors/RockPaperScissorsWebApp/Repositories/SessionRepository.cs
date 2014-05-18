using System.Collections.Generic;
using System.Web;

namespace RockPaperScissorsWebApp.Repositories
{
    public class SessionRepository<T>:IRepository<T>
    {
        private readonly string _sessionLabel;

        public SessionRepository(string sessionLabel)
        {
            _sessionLabel = sessionLabel;
        }

        public void Add(T item)
        {
            var items = HttpContext.Current.Session[_sessionLabel] as List<T> ?? new List<T>();
            items.Add(item);
            HttpContext.Current.Session[_sessionLabel] = items;
        }

        public void Save(IEnumerable<T> items)
        {
            HttpContext.Current.Session[_sessionLabel] = items;
        }

        public IEnumerable<T> GetAll()
        {
            return HttpContext.Current.Session[_sessionLabel] as List<T>;
        }

        public void Clear()
        {
            HttpContext.Current.Session[_sessionLabel] = new List<T>();
        }
    }
}