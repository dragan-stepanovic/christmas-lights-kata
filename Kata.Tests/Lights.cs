using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Tests
{
    public class Lights
    {
        private readonly int[] _lights;
        private readonly int[,] _lights2D;

        public Lights(int[] lights)
        {
            _lights = lights;

            _lights2D = new int[lights.Length, 1];
            for (var i = 0; i < lights.Length; i++)
                _lights2D[i, 0] = lights[i];
        }

        public Lights(int[,] lights2D)
        {
            _lights2D = lights2D;
        }

        public Lights AllOn()
        {
            return On(SelectAllLights());
        }

        public Lights AllOff()
        {
            return Off(SelectAllLights());
        }

        public Lights On(int[] toChange)
        {
            if (_lights != null)
                foreach (var lightPosition in RangeFrom(toChange))
                    _lights[lightPosition] = 1;

            if (_lights2D != null)
                ForEachSet(1);

            return this;
        }

        private void ForEachSet(int valueToSet)
        {
            for (var i = 0; i < _lights2D.GetLength(0); i++)
            for (var j = 0; j < _lights2D.GetLength(1); j++)
                _lights2D[i, j] = valueToSet;
        }

        public Lights Off(int[] toChange)
        {
            foreach (var lightPosition in RangeFrom(toChange))
                _lights[lightPosition] = 0;

            return this;
        }

        public Lights Toggle()
        {
            return TurnedOff() ? AllOn() : AllOff();
        }

        private int[] SelectAllLights()
        {
            return Enumerable.Range(0, _lights.Length).ToArray();
        }

        private static IEnumerable<int> RangeFrom(IReadOnlyList<int> toChange)
        {
            return Enumerable.Range(toChange[0], toChange[^1] - toChange[0] + 1).ToArray();
        }

        private bool TurnedOff()
        {
            //todo: assumption is that all lights have the same value; listing assumptions is good to incrementally grow the solution
            return _lights.First() == 0;
        }

        private bool Equals(Lights that)
        {
            if (_lights != null)
                return _lights.SequenceEqual(that._lights);

            if (_lights2D != null)
                for (var i = 0; i < _lights2D.GetLength(0); i++)
                for (var j = 0; j < _lights2D.GetLength(1); j++)
                    if (_lights2D[i, j] != that._lights2D[i, j])
                        return false;

            return true;
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
            if (_lights != null)
                return string.Join(", ", _lights);

            var stringBuilder = new StringBuilder("");
            for (var i = 0; i < _lights2D.GetLength(0); i++)
            {
                for (var j = 0; j < _lights2D.GetLength(1); j++)
                {
                    stringBuilder.Append(_lights2D[i, j]);
                    stringBuilder.Append(", ");
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append('\n');
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
    }
}