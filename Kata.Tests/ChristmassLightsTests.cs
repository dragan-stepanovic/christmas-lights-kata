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
            Assert.Equal(1, lights.On()[0]);
            Assert.Equal(1, lights.On()[0]);

            Assert.Equal(0, lights.Off()[0]);
            Assert.Equal(0, lights.Off()[0]);

            Assert.Equal(1, lights.ToggleTwo().First());
            Assert.Equal(0, lights.ToggleTwo().First());

            Assert.Equal(1, lights.On()[0]);
            Assert.Equal(0, lights.ToggleTwo().First());
            Assert.Equal(1, lights.On()[0]);
            Assert.Equal(0, lights.Off()[0]);
            Assert.Equal(1, lights.ToggleTwo().First());
        }

        [Fact]
        public void ManipulatesTwoLights()
        {
            var lights = new Lights(new[] {0, 0});
            Assert.Equal(new[] {1, 1}, lights.On());
            Assert.Equal(new[] {0, 0}, lights.Off());

            Assert.Equal(new[] {1, 1}, lights.ToggleTwo());
            Assert.Equal(new[] {0, 0}, lights.ToggleTwo());
            Assert.Equal(new[] {1, 1}, lights.ToggleTwo());
            Assert.Equal(new[] {0, 0}, lights.Off());
            Assert.Equal(new[] {1, 1}, lights.ToggleTwo());
            Assert.Equal(new[] {0, 0}, lights.ToggleTwo());
            Assert.Equal(new[] {1, 1}, lights.On());
            Assert.Equal(new[] {0, 0}, lights.ToggleTwo());
        }
    }

    public class Lights
    {
        private int[] _lights;

        public Lights(int[] lights)
        {
            _lights = lights;
        }

        public static Lights TurnedOff()
        {
            return new Lights(new[] {0, 0});
        }

        public int[] On()
        {
            _lights = new[] {1, 1};
            return _lights;
        }

        public int[] Off()
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