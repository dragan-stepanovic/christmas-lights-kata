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

        public Lights On(int[] toChange)
        {
            var array = Enumerable.Range(toChange[0], toChange[^1] - toChange[0] + 1).ToArray();

            foreach (var t in array)
                _lights[t] = 1;

            return this;
        }

        public Lights Off(int[] toChange = null)
        {
            if (toChange == null)
            {
                _lights = _lights.Select(_ => 0).ToArray();
                return this;
            }

            return OffNew(toChange);
        }

        public Lights OffNew(int[] toChange)
        {
            var array = Enumerable.Range(toChange[0], toChange[^1] - toChange[0] + 1).ToArray();

            foreach (var i in array)
                _lights[i] = 0;

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