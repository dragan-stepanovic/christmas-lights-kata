using System.Collections.Generic;
using System.Linq;
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
            Assert.Equal(new[] {1, 1}, Lights.TurnOnTwo());
            Assert.Equal(new[] {0, 0}, TurnOff());
            Assert.Equal(new[] {1, 1}, Toggle(new[] {0, 0}));
            Assert.Equal(new[] {0, 0}, Toggle(new[] {1, 1}));
        }

        private static IEnumerable<int> Toggle(IEnumerable<int> ints)
        {
            if (ints.SequenceEqual(new[] {0, 0}))
                return new[] {1, 1};

            return new[] {0, 0};
        }

        private static int[] TurnOff()
        {
            return new[] {0, 0};
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

        public static int[] TurnOnTwo()
        {
            return new[] {1, 1};
        }
    }
}