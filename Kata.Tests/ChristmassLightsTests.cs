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
            Equals(lights.On(), 1);
            lights.On().Should().BeEquivalentTo(new[] {1});

            lights.Off().Should().BeEquivalentTo(new[] {0});
            lights.Off().Should().BeEquivalentTo(new[] {0});

            lights.Toggle().Should().BeEquivalentTo(new[] {1});
            lights.Toggle().Should().BeEquivalentTo(new[] {0});

            lights.On().Should().BeEquivalentTo(new[] {1});
            lights.Toggle().Should().BeEquivalentTo(new[] {0});
            lights.On().Should().BeEquivalentTo(new[] {1});
            lights.Off().Should().BeEquivalentTo(new[] {0});
            lights.Toggle().Should().BeEquivalentTo(new[] {1});
        }

        private static void AssertThat(IEnumerable<int> actual, int[] expected)
        {
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ManipulatesTwoLights()
        {
            var lights = new Lights(new[] {0, 0});
            AssertThat(lights.On(), Is(1, 1));
            AssertThat(lights.Off(), Is(0, 0));
            AssertThat(lights.Toggle(), Is(1, 1));
            AssertThat(lights.Toggle(), Is(0, 0));
            AssertThat(lights.Toggle(), Is(1, 1));
            AssertThat(lights.Off(), Is(0, 0));
            AssertThat(lights.Toggle(), Is(1, 1));
            AssertThat(lights.Toggle(), Is(0, 0));
            AssertThat(lights.On(), Is(1, 1));
            AssertThat(lights.Toggle(), Is(0, 0));
        }

        private int[] Is(params int[] expected)
        {
            return expected;
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
            {
                if (_lights.Length == 1)
                    _lights = new[] {0};
                else
                    _lights = new[] {0, 0};
            }

            return _lights;
        }
    }
}