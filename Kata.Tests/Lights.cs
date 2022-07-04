using System.Linq;

namespace Kata.Tests
{
    public class Lights
    {
        private int[] _lights;
        private int[,] _lights2D;

        public Lights(int[] lights)
        {
            _lights = lights;

            _lights2D = new int[_lights.Length, 1];
            for (var i = 0; i < _lights.Length; i++)
                _lights2D[i, 0] = _lights[i];
        }

        public Lights On()
        {
            _lights = _lights.Select(_ => 1).ToArray();
            return this;
        }

        public Lights Off()
        {
            _lights = _lights.Select(_ => 0).ToArray();
            return this;
        }

        public Lights Toggle()
        {
            return TurnedOff() ? On() : Off();
        }

        private bool TurnedOff()
        {
            return _lights.First() == 0;
        }

        private bool Equals(Lights other)
        {
            return _lights.SequenceEqual(other._lights);
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