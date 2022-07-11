using System.Text;

namespace Kata
{
    public class Lights
    {
        private readonly int[,] _lights2D;

        public Lights(int[,] lights2D)
        {
            _lights2D = lights2D;
        }

        public Lights TurnOnBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            return SetValue(bottomLeft, topRight, 1);
        }

        public Lights TurnOffBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            return SetValue(bottomLeft, topRight, 0);
        }

        private Lights SetValue(Coordinate bottomLeft, Coordinate topRight, int valueToSet)
        {
            foreach (var position in Range.Between(bottomLeft, topRight))
                _lights2D[position.Row, position.Column] = valueToSet;

            return this;
        }

        public Lights ToggleBetween(Coordinate bottomLeft, Coordinate topRight)
        {
            foreach (var lightPosition in Range.Between(bottomLeft, topRight))
            {
                var light = new Light(_lights2D[lightPosition.Row, lightPosition.Column]);

                if (light.IsTurnedOff())
                    _lights2D[lightPosition.Row, lightPosition.Column] = 1;
                else
                    _lights2D[lightPosition.Row, lightPosition.Column] = 0;
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

    public class Light
    {
        private readonly int _state;

        public Light(int state)
        {
            _state = state;
        }

        public bool IsTurnedOff()
        {
            return _state == 0;
        }
    }
}