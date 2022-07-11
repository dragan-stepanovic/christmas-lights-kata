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
                _lights[position.Row, position.Column].TurnOn();

            return this;
        }

        public Lights TurnOffBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            foreach (var position in Range.Between(bottomLeft, topRight))
                _lights[position.Row, position.Column].TurnOff();

            return this;
        }

        public Lights ToggleBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            foreach (var position in Range.Between(bottomLeft, topRight))
            {
                if (LightAt(position).IsTurnedOff())
                    LightAt(position).TurnOn();
                else
                    LightAt(position).TurnOff();
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

    public class Light
    {
        private int _state;

        public Light(int state)
        {
            _state = state;
        }

        public bool IsTurnedOff()
        {
            return _state == 0;
        }

        public void TurnOn()
        {
            _state = 1;
        }

        public void TurnOff()
        {
            _state = 0;
        }

        public bool DoesNotEqual(Light other)
        {
            return _state != other._state;
        }

        public override string ToString()
        {
            return _state.ToString();
        }
    }
}