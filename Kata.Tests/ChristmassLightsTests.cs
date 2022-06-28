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
            AssertThatAfter(lights.On(), WeHave(1));
            AssertThatAfter(lights.On(), WeHave(1));

            AssertThatAfter(lights.Off(), WeHave(0));
            AssertThatAfter(lights.Off(), WeHave(0));

            AssertThatAfter(lights.Toggle(), WeHave(1));
            AssertThatAfter(lights.Toggle(), WeHave(0));

            AssertThatAfter(lights.On(), WeHave(1));
            AssertThatAfter(lights.Toggle(), WeHave(0));
            AssertThatAfter(lights.On(), WeHave(1));
            AssertThatAfter(lights.Off(), WeHave(0));
            AssertThatAfter(lights.Toggle(), WeHave(1));
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
        }

        // [Fact]
        // public void ManipulatesNLightsInTheSameRow()
        // {
        //     var lights = new Lights(new[] {0, 0, 0});
        //     AssertThatAfter(lights.On(), WeHave(1, 1, 1));
        // }


        private static void AssertThatAfter(IEnumerable<int> actual, IEnumerable<int> expected)
        {
            var newActual = new Lights(actual);
            newActual.Should().Be(new Lights(expected));

            actual.Should().BeEquivalentTo(expected);
        }

        private static IEnumerable<int> WeHave(params int[] expected)
        {
            return expected;
        }
    }

    public class Lights
    {
        private IEnumerable<int> _lights;

        public Lights(IEnumerable<int> lights)
        {
            _lights = lights;
        }

        public IEnumerable<int> On()
        {
            _lights = _lights.Select(_ => 1);
            return _lights;
        }

        public IEnumerable<int> Off()
        {
            _lights = _lights.Select(_ => 0);
            return _lights;
        }

        public IEnumerable<int> Toggle()
        {
            return LightsTurnedOff() ? On() : Off();
        }

        private bool LightsTurnedOff()
        {
            return _lights.First() == 0;
        }

        protected bool Equals(Lights other)
        {
            return _lights.SequenceEqual(other._lights);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Lights) obj);
        }

        public override int GetHashCode()
        {
            return (_lights != null ? _lights.GetHashCode() : 0);
        }
    }
}