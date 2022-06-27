using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurnsOnLights()
        {
            Assert.Equal(1, Lights.TurnOn());
        }
    }

    public static class Lights
    {
        public static int TurnOn()
        {
            return 1;
        }
    }
}