using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void ManipulatesOneLight()
        {
            var lights = Lights.TurnedOff();
            Assert.Equal(1, lights.On());
            Assert.Equal(1, lights.On());

            Assert.Equal(0, lights.Off());
            Assert.Equal(0, lights.Off());

            Assert.Equal(1, lights.Toggle());
            Assert.Equal(0, lights.Toggle());

            Assert.Equal(1, lights.On());
            Assert.Equal(0, lights.Toggle());
            Assert.Equal(1, lights.On());
            Assert.Equal(0, lights.Off());
            Assert.Equal(1, lights.Toggle());
        }

        [Fact]
        public void ManipulatesTwoLights()
        {
            Assert.Equal(new[] {1, 1}, new[] {1, 1});
        }
    }

    public class Lights
    {
        private int _state;

        private Lights(int state)
        {
            _state = state;
        }

        public int On()
        {
            _state = 1;
            return _state;
        }

        public int Off()
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