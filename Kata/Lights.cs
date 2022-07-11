using System.Text;

namespace Kata
{
    public class Lights
    {
        private Light[,] _lights;

        public Lights(int[,] lights2D)
        {
            ArrayOfLightsFrom(lights2D);
        }

        private void ArrayOfLightsFrom(int[,] lights2D)
        {
            _lights = new Light[lights2D.GetLength(0), lights2D.GetLength(1)];
            for (var row = 0; row < lights2D.GetLength(0); row++)
            for (var column = 0; column < lights2D.GetLength(1); column++)
                _lights[row, column] = new Light(lights2D[row, column]);
        }

        public Lights TurnOnBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            foreach (var position in Range.Between(bottomLeft, topRight))
                LightAt(position).TurnOn();
            return this;
        }

        public Lights TurnOffBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            foreach (var position in Range.Between(bottomLeft, topRight))
                LightAt(position).TurnOff();
            return this;
        }

        public Lights ToggleBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            foreach (var position in Range.Between(bottomLeft, topRight))
            {
                LightAt(position).Toggle();
            }

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
            if (obj.GetType() != GetType()) return false;
            return Equals((Lights) obj);
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