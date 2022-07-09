using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Tests
{
    public class Lights
    {
        private readonly int[,] _lights2D;

        public Lights(IReadOnlyList<int> lights1D) : this(Lights2DFrom(lights1D))
        {
        }

        public Lights(int[,] lights2D)
        {
            _lights2D = lights2D;
        }

        private static int[,] Lights2DFrom(IReadOnlyList<int> lights1D)
        {
            var newList2D = new int[1, lights1D.Count];
            for (var i = 0; i < lights1D.Count; i++)
                newList2D[0, i] = lights1D[i];
            return newList2D;
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
            if (_lights2D != null)
                ForEachSet(1, toChange);

            return this;
        }

        public Lights Off(int[] toChange)
        {
            if (_lights2D != null)
                ForEachSet(0, toChange);

            return this;
        }

        public Lights Toggle()
        {
            return TurnedOff() ? AllOn() : AllOff();
        }

        private void ForEachSet(int valueToSet, IReadOnlyList<int> toChange)
        {
            foreach (var index in RangeFrom(toChange))
                _lights2D[0, index] = valueToSet;
        }

        private int[] SelectAllLights()
        {
            return Enumerable.Range(0, _lights2D.GetLength(1)).ToArray();
        }

        private static IEnumerable<int> RangeFrom(IReadOnlyList<int> toChange)
        {
            return Enumerable.Range(toChange[0], toChange[^1] - toChange[0] + 1).ToArray();
        }

        private bool TurnedOff()
        {
            //todo: assumption is that all lights have the same value; listing assumptions is good to incrementally grow the solution
            return _lights2D[0, 0] == 0;
        }

        private bool Equals(Lights that)
        {
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
            return _lights2D != null ? _lights2D.GetHashCode() : 0;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("");
            for (var i = 0; i < _lights2D.GetLength(0); i++)
            {
                for (var j = 0; j < _lights2D.GetLength(1); j++)
                    stringBuilder.Append(_lights2D[i, j] + ", ");

                stringBuilder.Remove(stringBuilder.Length - 2, 2);
                stringBuilder.Append('\n');
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
    }
}