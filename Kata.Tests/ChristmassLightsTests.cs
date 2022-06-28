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
            var lights = new Lights(new[] {0, 0});
            Assert.Equal(new[] {1, 1}, lights.TurnOnTwo());
            Assert.Equal(new[] {0, 0}, lights.TurnOffTwo());

            Assert.Equal(new[] {1, 1}, lights.ToggleTwo());
            Assert.Equal(new[] {0, 0}, lights.ToggleTwo());
            Assert.Equal(new[] {1, 1}, lights.ToggleTwo());
            Assert.Equal(new[] {0, 0}, lights.TurnOffTwo());
            Assert.Equal(new[] {1, 1}, lights.ToggleTwo());
            Assert.Equal(new[] {0, 0}, lights.ToggleTwo());
            Assert.Equal(new[] {1, 1}, lights.TurnOnTwo());
            Assert.Equal(new[] {0, 0}, lights.ToggleTwo());
        }
    }

    public class Lights
    {
        private int[] _lights;

        private Lights(int state)
        {
            _lights = new[] {state, 0};
        }

        public Lights(int[] lights)
        {
            _lights = lights;
        }

        public int Off()
        {
            _lights[0] = 0;
            return _lights[0];
        }

        public int Toggle()
        {
            if (_lights[0] == 1)
                _lights[0] = 0;

            else
                _lights[0] = 1;

            return _lights[0];
        }

        public static Lights TurnedOff()
        {
            return new Lights(0);
        }

        public int On()
        {
            _lights[0] = 1;
            return _lights[0];
        }

        public int[] TurnOnTwo()
        {
            _lights = new[] {1, 1};
            return _lights;
        }

        public int[] TurnOffTwo()
        {
            _lights = new[] {0, 0};
            return _lights;
        }

        public IEnumerable<int> ToggleTwo()
        {
            if (_lights.SequenceEqual(new[] {0, 0}))
                _lights = new[] {1, 1};
            else
                _lights = new[] {0, 0};

            return _lights;
        }
    }
}