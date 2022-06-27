using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurnsOnLights()
        {
            var lights = new Lights(0);
            Assert.Equal(1, lights.TurnOn());
            Assert.Equal(1, lights.TurnOn());

            Assert.Equal(0, lights.TurnOff());
            Assert.Equal(0, lights.TurnOff());

            Assert.Equal(1, lights.Toggle());
            Assert.Equal(0, new Lights(1).Toggle());
        }
    }

    public class Lights
    {
        private int _state;

        public Lights(int state)
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

            return 1;
        }
    }
}