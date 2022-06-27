using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurnsOnLights()
        {
            Assert.Equal(1, Lights.TurnOn());
            Assert.Equal(0, Lights.TurnOff());
            Assert.Equal(1, new Lights().Toggle());
            Assert.Equal(0, new Lights(1).Toggle());
        }
    }

    public class Lights
    {
        private readonly int _state;

        public Lights(int state = 0)
        {
            _state = state;
        }

        public static int TurnOn()
        {
            return 1;
        }

        public static int TurnOff()
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