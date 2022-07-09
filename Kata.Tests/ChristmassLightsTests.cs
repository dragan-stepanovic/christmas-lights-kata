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
            After(lights.AllOn(), WeShouldHave(1));
            After(lights.AllOn(), WeShouldHave(1));

            After(lights.Off(), WeShouldHave(0));
            After(lights.Off(), WeShouldHave(0));

            After(lights.Toggle(), WeShouldHave(1));
            After(lights.Toggle(), WeShouldHave(0));

            After(lights.AllOn(), WeShouldHave(1));
            After(lights.Toggle(), WeShouldHave(0));
            After(lights.AllOn(), WeShouldHave(1));
            After(lights.Off(), WeShouldHave(0));
            After(lights.Toggle(), WeShouldHave(1));
        }

        [Fact]
        public void ManipulatesTwoLights()
        {
            var lights = new Lights(new[] {0, 0});
            After(lights.AllOn(), WeShouldHave(1, 1));
            After(lights.Off(), WeShouldHave(0, 0));

            After(lights.Toggle(), WeShouldHave(1, 1));
            After(lights.Toggle(), WeShouldHave(0, 0));
            After(lights.Toggle(), WeShouldHave(1, 1));

            After(lights.Off(), WeShouldHave(0, 0));
            After(lights.Toggle(), WeShouldHave(1, 1));
            After(lights.Toggle(), WeShouldHave(0, 0));
            After(lights.AllOn(), WeShouldHave(1, 1));
        }

        [Fact]
        public void ManipulatesNLightsInTheSameRow()
        {
            Lights(0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1));
            Lights(0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).Off().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0).Toggle().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).Toggle().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).Off().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1, 1, 1));
        }

        [Fact]
        public void ManipulateIndividualLightsInTheSameRow()
        {
            Lights(0, 0).On(new[] {1}).Should().Be(Lights(0, 1));
            Lights(0, 0).On(new[] {0}).Should().Be(Lights(1, 0));
            Lights(0, 0).On(new[] {0, 1}).Should().Be(Lights(1, 1));
            Lights(0, 0, 0).On(new[] {0, 1}).Should().Be(Lights(1, 1, 0));
            Lights(0, 0, 0, 0).On(new[] {1, 2}).Should().Be(Lights(0, 1, 1, 0));
            Lights(0, 1, 0, 1).On(new[] {1, 2}).Should().Be(Lights(0, 1, 1, 1));
            Lights(0, 1, 0, 1).On(new[] {0, 3}).Should().Be(Lights(1, 1, 0, 1));
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
}