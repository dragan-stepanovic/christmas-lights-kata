using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core;

namespace Kata.Tests
{
    public class Lights
    {
        private readonly int[,] _lights2D;

        public Lights(int[,] lights2D)
        {
            _lights2D = lights2D;
        }

        public Lights AllOn()
        {
            return SetValue(ZeroZero(), TopUpperRightOf(_lights2D), 1);
        }

        public static Pair<int, int> ZeroZero()
        {
            return Coordinate(0, 0);
        }

        private static Pair<int, int> Coordinate(int first, int second)
        {
            return new Pair<int, int>(first, second);
        }

        public Lights TurnOnBetween(Pair<int, int> bottomLeft, Pair<int, int> upperRight)
        {
            return SetValue(bottomLeft, upperRight, 1);
        }

        private Lights SetValue(Pair<int, int> bottomLeft, Pair<int, int> upperRight, int valueToSet)
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
                    .Select(column => Coordinate(row, column)));

            return result;
        }

        public Lights ToggleBetween(Pair<int, int> bottomLeft, Pair<int, int> upperRight)
        {
            foreach (var lightPosition in RangeFrom(bottomLeft, upperRight))
            {
                if (_lights2D[lightPosition.First, lightPosition.Second] == 0)
                    _lights2D[lightPosition.First, lightPosition.Second] = 1;
                else
                    _lights2D[lightPosition.First, lightPosition.Second] = 0;
            }

            return this;
        }

        private static Pair<int, int> TopUpperRightOf(int[,] lights2D)
        {
            return Coordinate(lights2D.GetLength(0) - 1, lights2D.GetLength(1) - 1);
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