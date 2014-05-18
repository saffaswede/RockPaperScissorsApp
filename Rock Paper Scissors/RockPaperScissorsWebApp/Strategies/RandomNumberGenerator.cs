using System;

namespace RockPaperScissorsWebApp.Strategies
{
    public static class RandomNumberGenerator
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);

        public static int GetRandomNumber(int seed)
        {
            return Random.Next(seed);
        }
    }
}