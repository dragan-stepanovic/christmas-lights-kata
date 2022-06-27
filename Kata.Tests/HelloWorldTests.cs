using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurnsOnLights()
        {
            Assert.Equal(1, new Lights(0).TurnOn());
            Assert.Equal(1, new Lights(1).TurnOn());
            Assert.Equal(0, new Lights(1).TurnOff());
            Assert.Equal(0, new Lights(0).TurnOff());
            Assert.Equal(1, new Lights(0).Toggle());
            Assert.Equal(0, new Lights(1).Toggle());
        }
    }

    public class Lights
    {
        private readonly int _state;

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
                return 0;

            return 1;
        }
    }
}