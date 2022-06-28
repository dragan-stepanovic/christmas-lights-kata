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
            Assert.Equal(new[] {0, 0}, Lights.TurnOffTwo());
            var lights = new Lights(new[] {0, 0});
            Assert.Equal(new[] {1, 1}, lights.ToggleTwo(lights._lights));
            Assert.Equal(new[] {0, 0}, lights.ToggleTwo(new[] {1, 1}));
        }
    }

    public class Lights
    {
        public readonly int[] _lights;
        private int _state;

        private Lights(int state)
        {
            _state = state;
        }

        public Lights(int[] lights)
        {
            _lights = lights;
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

        public static int[] TurnOffTwo()
        {
            return new[] {0, 0};
        }

        public IEnumerable<int> ToggleTwo(IEnumerable<int> lights)
        {
            if (lights.SequenceEqual(new[] {0, 0}))
                return new[] {1, 1};

            return new[] {0, 0};
        }

        public static IEnumerable<int> New(int[] lights)
        {
            return new Lights(lights)._lights;
        }
    }
}