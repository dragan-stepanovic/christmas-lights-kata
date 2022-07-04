using System.Linq;

namespace Kata.Tests
{
    public class Lights
    {
        private readonly int[] _lights;
        private int[,] _lights2D;

        public Lights(int[] lights)
        {
            _lights = lights;
            CopyParallelArrays();
        }

        public Lights On()
        {
            for (var i = 0; i < _lights2D.GetLength(0); i++)
                _lights2D[i, 0] = 1;

            return this;
        }

        public Lights Off()
        {
            for (var i = 0; i < _lights2D.GetLength(0); i++)
                _lights2D[i, 0] = 0;

            return this;
        }

        public Lights Toggle()
        {
            return TurnedOff() ? On() : Off();
        }

        private bool TurnedOff()
        {
            //todo: assumption is that all lights have the same value; listing assumptions is good to incrementally grow the solution
            return _lights2D[0, 0] == 0;
        }

        private bool Equals(Lights that)
        {
            if (that._lights2D.Length != _lights2D.Length)
                return false;

            for (var i = 0; i < _lights2D.GetLength(0); i++)
                if (_lights2D[i, 0] != that._lights2D[i, 0])
                    return false;

            return true;
        }

        private void CopyParallelArrays()
        {
            _lights2D = new int[_lights.Length, 1];
            for (var i = 0; i < _lights2D.GetLength(0); i++)
                _lights2D[i, 0] = _lights[i];
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