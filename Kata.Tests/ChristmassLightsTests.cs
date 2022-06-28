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
            Assert.Equal(new[] {1, 1}, Lights.ToggleTwo(Lights.New(new[] {0, 0})));
            Assert.Equal(new[] {0, 0}, Lights.ToggleTwo(new[] {1, 1}));
        }
    }

    public class Lights
    {
        private readonly int[] _lights;
        private int _state;

        private Lights(int state)
        {
            _state = state;
        }

        private Lights(int[] lights)
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

        public static IEnumerable<int> ToggleTwo(IEnumerable<int> lights)
        {
            if (lights.SequenceEqual(new[] {0, 0}))
                return new[] {1, 1};

            return new[] {0, 0};
        }

        public static IEnumerable<int> New(int[] lights)
        {
            new Lights(lights);
            return lights;
        }
    }
}