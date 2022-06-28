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

        [Fact]
        public void ManipulatesTwoLights()
        {
            var lights = new Lights(new[] {0, 0});
            AssertThatAfter(lights.On(), WeHave(1, 1));
            AssertThatAfter(lights.Off(), WeHave(0, 0));
            AssertThatAfter(lights.Toggle(), WeHave(1, 1));
            AssertThatAfter(lights.Toggle(), WeHave(0, 0));
            AssertThatAfter(lights.Toggle(), WeHave(1, 1));
            AssertThatAfter(lights.Off(), WeHave(0, 0));
            AssertThatAfter(lights.Toggle(), WeHave(1, 1));
            AssertThatAfter(lights.Toggle(), WeHave(0, 0));
            AssertThatAfter(lights.On(), WeHave(1, 1));
            AssertThatAfter(lights.Toggle(), WeHave(0, 0));
        }

        private static void AssertThatAfter(IEnumerable<int> actual, IEnumerable<int> expected)
        {
            actual.Should().BeEquivalentTo(expected);
        }

        private static IEnumerable<int> WeHave(params int[] expected)
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