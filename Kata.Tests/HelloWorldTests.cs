using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurnsOnLights()
        {
            var lights = Lights.TurnedOff();
            Assert.Equal(1, lights.TurnOn());
            Assert.Equal(1, lights.TurnOn());

            Assert.Equal(0, lights.TurnOff());
            Assert.Equal(0, lights.TurnOff());

            Assert.Equal(1, lights.Toggle());
            Assert.Equal(0, lights.Toggle());

            Assert.Equal(1, lights.TurnOn());
            Assert.Equal(0, lights.Toggle());
        }
    }

    public class Lights
    {
        private int _state;

        private Lights(int state)
        {
            _state = state;
        }

        public int TurnOn()
        {
            _state = 1;
            return _state;
        }

        public int TurnOff()
        {
            _state = 0;
            return _state;
        }

        public int Toggle()
        {
            if (_state == 1)
                _state = 0;
            else
                _state = 1;

            return _state;
        }

        public static Lights TurnedOff()
        {
            return new Lights(0);
        }
    }
}