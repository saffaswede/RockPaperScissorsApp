using System.Collections.Generic;
using RockPaperScissorsWebApp.Enums;

namespace RockPaperScissorsWebApp.Tests
{
    public class GestureCollectionBuilder
    {
        private readonly List<Gesture> _gestures;

        public GestureCollectionBuilder()
        {
            _gestures = new List<Gesture>();
        }

        public GestureCollectionBuilder Clear()
        {
            _gestures.Clear();
            return this;
        }

        public GestureCollectionBuilder AddRock()
        {
            _gestures.Add(Gesture.Rock);
            return this;
        }

        public GestureCollectionBuilder AddPaper()
        {
            _gestures.Add(Gesture.Paper );
            return this;
        }

        public GestureCollectionBuilder AddScissors()
        {
            _gestures.Add( Gesture.Scissors );
            return this;
        }

        public List<Gesture> Build()
        {
            return _gestures;
        }
    }
}
