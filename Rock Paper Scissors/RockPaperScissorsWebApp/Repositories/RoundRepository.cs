using System.Collections.Generic;
using System.Net;
using System.Web;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Repositories
{
    public class RoundRepository : IRoundRepository
    {
        private readonly IList<Round> _rounds;
        //private HttpCookie cookie = new HttpCookie("Cookie");

        public RoundRepository()
        {
            _rounds = new List<Round>();
            //cookie 
        }

        public void Add(Round round)
        {
            _rounds.Add(round);


            //cookie.Value = 
        }

        public IEnumerable<Round> GetAll()
        {
            return _rounds;
        }

        public void Clear()
        {
            _rounds.Clear();
        }
    }
}