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
            return 1;
        }

        public int TurnOff()
        {
            return 0;
        }

        public int Toggle()
        {
            if (_state == 1)
            {
                _state = 0;
                return 0;
            }

            _state = 1;
            return 1;
        }

        public static Lights TurnedOff()
        {
            return new Lights(0);
        }
    }
}