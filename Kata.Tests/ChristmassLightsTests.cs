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
            After(lights.On(), WeShouldHave(1));
            After(lights.On(), WeShouldHave(1));

            After(lights.Off(), WeShouldHave(0));
            After(lights.Off(), WeShouldHave(0));

            After(lights.Toggle(), WeShouldHave(1));
            After(lights.Toggle(), WeShouldHave(0));

            After(lights.On(), WeShouldHave(1));
            After(lights.Toggle(), WeShouldHave(0));
            After(lights.On(), WeShouldHave(1));
            After(lights.Off(), WeShouldHave(0));
            After(lights.Toggle(), WeShouldHave(1));
        }

        [Fact]
        public void ManipulatesTwoLights()
        {
            var lights = new Lights(new[] {0, 0});
            After(lights.On(), WeShouldHave(1, 1));
            After(lights.Off(), WeShouldHave(0, 0));

            After(lights.Toggle(), WeShouldHave(1, 1));
            After(lights.Toggle(), WeShouldHave(0, 0));
            After(lights.Toggle(), WeShouldHave(1, 1));

            After(lights.Off(), WeShouldHave(0, 0));
            After(lights.Toggle(), WeShouldHave(1, 1));
            After(lights.Toggle(), WeShouldHave(0, 0));
            After(lights.On(), WeShouldHave(1, 1));
        }

        [Fact]
        public void ManipulatesNLightsInTheSameRow()
        {
            Lights(0, 0, 0).On().Should().Be(Lights(1, 1, 1));
            Lights(0, 0, 0).On().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).Off().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0).Toggle().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).Toggle().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0).On().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).Off().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0, 0, 0).On().Should().Be(Lights(1, 1, 1, 1, 1));
        }

        private static Lights Lights(params int[] initial)
        {
            return new Lights(initial);
        }

        private static void After(Lights actual, Lights expected)
        {
            actual.Should().Be(expected);
        }

        private static Lights WeShouldHave(params int[] expected)
        {
            return new Lights(expected);
        }
    }

    public class Lights
    {
        private int[] _lights;
        private int[,] _lights2D;

        public Lights(int[] lights)
        {
            _lights = lights;
            _lights2D = new int[_lights.Length, 1];
            for (var i = 0; i < _lights.Length; i++)
            {
                _lights2D[i, 0] = _lights[i];
            }
        }

        public Lights On()
        {
            _lights = _lights.Select(_ => 1).ToArray();
            return this;
        }

        public Lights Off()
        {
            _lights = _lights.Select(_ => 0).ToArray();
            return this;
        }

        public Lights Toggle()
        {
            return TurnedOff() ? On() : Off();
        }

        private bool TurnedOff()
        {
            return _lights.First() == 0;
        }

        private bool Equals(Lights other)
        {
            return _lights.SequenceEqual(other._lights);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Lights) obj);
        }

        public override int GetHashCode()
        {
            return _lights != null ? _lights.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Join(", ", _lights);
        }
    }
}