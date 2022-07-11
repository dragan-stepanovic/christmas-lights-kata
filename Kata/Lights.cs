using System;
using System.Linq;
using System.Text;

namespace Kata
{
    public class Lights
    {
        private Light[,] _lights;

        public Lights(int[,] lights)
        {
            ArrayOfLightsFrom(lights);
        }

        private void ArrayOfLightsFrom(int[,] lights)
        {
            var test = Coordinates.Between(Coordinate.ZeroZero,
                Coordinate.At(NumberOfRows(lights) - 1, NumberOfColumns(lights) - 1));

            _lights = new Light[NumberOfRows(lights), NumberOfColumns(lights)];

            test.ToList().ForEach(c => _lights[c.Row, c.Column] = new Light(lights[c.Row, c.Column]));
        }

        private static int NumberOfColumns(int[,] lights)
        {
            return lights.GetLength(1);
        }

        private static int NumberOfRows(int[,] lights)
        {
            return lights.GetLength(0);
        }

        public Lights TurnOnBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            return DoActionBetween(bottomLeft, topRight, light => light.TurnOn());
        }

        public Lights TurnOffBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            return DoActionBetween(bottomLeft, topRight, light => light.TurnOff());
        }

        public Lights ToggleBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            return DoActionBetween(bottomLeft, topRight, light => light.Toggle());
        }

        private Lights DoActionBetween(Coordinate bottomLeft, Coordinate topRight, Action<Light> action)
        {
            foreach (var position in Coordinates.Between(bottomLeft, topRight))
                action.Invoke(LightAt(position));

            return this;
        }

        private Light LightAt(Coordinate position)
        {
            return _lights[position.Row, position.Column];
        }

        private bool Equals(Lights that)
        {
            for (var i = 0; i < _lights.GetLength(0); i++)
            for (var j = 0; j < _lights.GetLength(1); j++)
                if (_lights[i, j].DoesNotEqual(that._lights[i, j]))
                    return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Lights) obj);
        }

        public override int GetHashCode()
        {
            return _lights != null ? _lights.GetHashCode() : 0;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("");
            for (var i = 0; i < _lights.GetLength(0); i++)
            {
                for (var j = 0; j < _lights.GetLength(1); j++)
                    stringBuilder.Append(_lights[i, j] + ", ");

                stringBuilder.Remove(stringBuilder.Length - 2, 2);
                stringBuilder.Append('\n');
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
    }
}