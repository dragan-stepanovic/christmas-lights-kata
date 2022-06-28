using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        public static TheoryData<Lights, Func<Lights, Lights>, Lights> BeforeData =>
            new()
            {
                {Lights(0, 0, 0), before => before.On(), Lights(1, 1, 1)},
                {Lights(0, 0, 0), before => before.On(), Lights(1, 1, 1)},
                {Lights(1, 1, 1), before => before.Off(), Lights(0, 0, 0)},
                {Lights(0, 0, 0), before => before.Toggle(), Lights(1, 1, 1)},
                {Lights(1, 1, 1), before => before.Toggle(), Lights(0, 0, 0)},
                {Lights(0, 0, 0), before => before.On(), Lights(1, 1, 1)},
                {Lights(0, 0, 0), before => before.On(), Lights(1, 1, 1)},
                {Lights(0, 0, 0), before => before.On(), Lights(1, 1, 1)},
            };

        // After(lights3.On(), WeShouldHave(1, 1, 1));
        // After(lights3.Off(), WeShouldHave(0, 0, 0));
        //
        // var lights5 = new Lights(new[] {0, 0, 0, 0, 0});
        // After(lights5.On(), WeShouldHave(1, 1, 1, 1, 1));


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

        [Theory]
        [MemberData(nameof(BeforeData))]
        public void ManipulatesNLightsInTheSameRow(Lights before, Func<Lights, Lights> operation, Lights after)
        {
            var lights3 = new Lights(new[] {0, 0, 0});
            After(operation(before), after);

            After(lights3.On(), WeShouldHave(1, 1, 1));
            After(lights3.Off(), WeShouldHave(0, 0, 0));
            After(lights3.Toggle(), WeShouldHave(1, 1, 1));
            After(lights3.Toggle(), WeShouldHave(0, 0, 0));
            After(lights3.On(), WeShouldHave(1, 1, 1));
            After(lights3.On(), WeShouldHave(1, 1, 1));
            After(lights3.Off(), WeShouldHave(0, 0, 0));

            var lights5 = new Lights(new[] {0, 0, 0, 0, 0});
            After(lights5.On(), WeShouldHave(1, 1, 1, 1, 1));
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
        private IEnumerable<int> _lights;

        public Lights(IEnumerable<int> lights)
        {
            _lights = lights;
        }

        public Lights On()
        {
            _lights = _lights.Select(_ => 1);
            return this;
        }

        public Lights Off()
        {
            _lights = _lights.Select(_ => 0);
            return this;
        }

        public Lights Toggle()
        {
            return LightsTurnedOff() ? On() : Off();
        }

        private bool LightsTurnedOff()
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