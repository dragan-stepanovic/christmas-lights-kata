using System.Collections.Generic;
using System.Linq;

namespace Kata.Tests
{
    public class Lights
    {
        private int[] _lights;

        public Lights(int[] lights)
        {
            _lights = lights;
        }

        public Lights AllOn()
        {
            return On(Enumerable.Range(0, _lights.Length).ToArray());
        }

        public Lights On(IEnumerable<int> toChange)
        {
            foreach (var t in toChange)
                _lights[t] = 1;

            return this;
        }

        public Lights Off(int[] ints = null)
        {
            if (ints != null)
                _lights[1] = 0;
            else
                _lights = _lights.Select(_ => 0).ToArray();
            
            return this;
        }

        public Lights Toggle()
        {
            return TurnedOff() ? AllOn() : Off();
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