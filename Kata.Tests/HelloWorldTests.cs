using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurnsOnLights()
        {
            Assert.Equal(1, Lights.TurnOn());
            Assert.Equal(0, Lights.TurnOff());
        }
    }

    public static class Lights
    {
        public static int TurnOn()
        {
            return 1;
        }

        public static int TurnOff()
        {
            return 1;
        }
    }
}