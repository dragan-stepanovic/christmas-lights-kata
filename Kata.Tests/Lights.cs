using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core;

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

        public Lights On(int[] columns)
        {
            return On(new Pair<int, int>(0, columns[0]), new Pair<int, int>(0, columns[1]), 1);
        }

        public Lights On(Pair<int, int> upperRight)
        {
            return On(new Pair<int, int>(0, 0), upperRight, 1);
        }

        private Lights On(Pair<int, int> bottomLeft, Pair<int, int> upperRight, int valueToSet)
        {
            foreach (var position in RangeFrom(bottomLeft, upperRight))
                _lights2D[position.First, position.Second] = valueToSet;

            return this;
        }

        private static List<Pair<int, int>> RangeFrom(Pair<int, int> bottomLeft, Pair<int, int> upperRight)
        {
            var result = new List<Pair<int, int>>();
            for (var row = bottomLeft.First; row <= upperRight.First; row++)
                result.AddRange(Enumerable.Range(bottomLeft.Second, upperRight.Second - bottomLeft.Second + 1)
                    .Select(column => new Pair<int, int>(row, column)));

            return result;
        }

        public Lights Off(int[] toChange)
        {
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
                _lights2D[index.First, index.Second] = valueToSet;
        }

        private int[] SelectAllLights()
        {
            return new[] {0, _lights2D.GetLength(1) - 1};
        }

        private static List<Pair<int, int>> RangeFrom(IReadOnlyList<int> upperRight)
        {
            var range = Enumerable.Range(upperRight[0], upperRight[1] - upperRight[0] + 1).ToArray();
            var result = range.Select(t => new Pair<int, int>(0, t)).ToList();
            return result;
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