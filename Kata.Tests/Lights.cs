using System.Collections.Generic;
using System.Linq;

namespace Kata.Tests
{
    public class Lights
    {
        private readonly int[] _lights;

        public Lights(int[] lights)
        {
            _lights = lights;
        }

        public Lights AllOn()
        {
            return On(AllLights());
        }

        public Lights On(int[] toChange)
        {
            foreach (var t in RangeFrom(toChange))
                _lights[t] = 1;

            return this;
        }

        private static IEnumerable<int> RangeFrom(IReadOnlyList<int> toChange)
        {
            return Enumerable.Range(toChange[0], toChange[^1] - toChange[0] + 1).ToArray();
        }

        public Lights AllOff()
        {
            return Off(AllLights());
        }

        public Lights Off(int[] toChange)
        {
            foreach (var i in RangeFrom(toChange))
                _lights[i] = 0;

            return this;
        }

        public Lights Toggle()
        {
            return TurnedOff() ? AllOn() : AllOff();
        }

        private int[] AllLights()
        {
            return Enumerable.Range(0, _lights.Length).ToArray();
        }

        private bool TurnedOff()
        {
            //todo: assumption is that all lights have the same value; listing assumptions is good to incrementally grow the solution
            return _lights.First() == 0;
        }

        private bool Equals(Lights that)
        {
            return _lights.SequenceEqual(that._lights);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Lights) obj);
        }

        public override int GetHashCode()
        {
            return _lights != null ? _lights.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Join(", ", _lights);
        }
    }
}