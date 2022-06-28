using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void ManipulatesOneLight()
        {
            var lights = new Lights(new[] {0});
            lights.On().Should().BeEquivalentTo(new[] {1});
            lights.On().Should().BeEquivalentTo(new[] {1});

            lights.Off().Should().BeEquivalentTo(new[] {0});
            lights.Off().Should().BeEquivalentTo(new[] {0});

            lights.Toggle().Should().BeEquivalentTo(new[] {1});
            lights.Toggle().First().Should().Be(0);

            lights.On().First().Should().Be(1);
            lights.Toggle().First().Should().Be(0);
            lights.On().First().Should().Be(1);
            lights.Off().First().Should().Be(0);
            lights.Toggle().First().Should().Be(1);
        }

        [Fact]
        public void ManipulatesTwoLights()
        {
            var lights = new Lights(new[] {0, 0});
            Assert.Equal(new[] {1, 1}, lights.On());
            Assert.Equal(new[] {0, 0}, lights.Off());

            Assert.Equal(new[] {1, 1}, lights.Toggle());
            Assert.Equal(new[] {0, 0}, lights.Toggle());
            Assert.Equal(new[] {1, 1}, lights.Toggle());
            Assert.Equal(new[] {0, 0}, lights.Off());
            Assert.Equal(new[] {1, 1}, lights.Toggle());
            Assert.Equal(new[] {0, 0}, lights.Toggle());
            Assert.Equal(new[] {1, 1}, lights.On());
            Assert.Equal(new[] {0, 0}, lights.Toggle());
        }
    }

    public class Lights
    {
        private int[] _lights;

        public Lights(int[] lights)
        {
            _lights = lights;
        }

        public int[] On()
        {
            if (_lights.Length == 1)
                _lights = new[] {1};

            else
                _lights = new[] {1, 1};

            return _lights;
        }

        public int[] Off()
        {
            if (_lights.Length == 1)
            {
                _lights = new[] {0};
            }
            else
            {
                _lights = new[] {0, 0};
            }

            return _lights;
        }

        public IEnumerable<int> Toggle()
        {
            if (_lights.All(l => l == 0))
            {
                if (_lights.Length == 1)
                    _lights = new[] {1};
                else
                    _lights = new[] {1, 1};
            }
            else

                _lights = new[] {0, 0};

            return _lights;
        }
    }
}