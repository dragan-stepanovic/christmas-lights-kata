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

        public Lights TurnOnBetween(Pair<int, int> bottomLeft, Pair<int, int> topRight)
        {
            return SetValue(new Coordinate(bottomLeft.First, bottomLeft.Second),
                new Coordinate(topRight.First, topRight.Second), 1);
        }

        public Lights TurnOffBetween(Pair<int, int> bottomLeft, Pair<int, int> topRight)
        {
            return SetValue(new Coordinate(bottomLeft.First, bottomLeft.Second),
                new Coordinate(topRight.First, topRight.Second), 0);
        }

        private Lights SetValue(Coordinate bottomLeft, Coordinate topRight, int valueToSet)
        {
            foreach (var position in RangeBetween(bottomLeft, topRight))
                _lights2D[position.First, position.Second] = valueToSet;

            return this;
        }

        private static List<Pair<int, int>> RangeBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            var result = new List<Pair<int, int>>();
            for (var row = bottomLeft.Row; row <= topRight.Row; row++)
                result.AddRange(Enumerable.Range(bottomLeft.Column, topRight.Column - bottomLeft.Column + 1)
                    .Select(column => Coordinate.At(row, column)));
            return result;
        }

        public Lights ToggleBetween(Pair<int, int> bottomLeft, Pair<int, int> topRight)
        {
            foreach (var lightPosition in RangeBetween(new Coordinate(bottomLeft.First, bottomLeft.Second),
                         new Coordinate(topRight.First, topRight.Second)))
            {
                if (_lights2D[lightPosition.First, lightPosition.Second] == 0)
                    _lights2D[lightPosition.First, lightPosition.Second] = 1;
                else
                    _lights2D[lightPosition.First, lightPosition.Second] = 0;
            }

            return this;
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