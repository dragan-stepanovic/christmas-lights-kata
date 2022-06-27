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
            Assert.Equal(1, new Lights().Toggle());
            Assert.Equal(0, new Lights().Toggle(1));
        }
    }

    public class Lights
    {
        public static int TurnOn()
        {
            return 1;
        }

        public static int TurnOff()
        {
            return 0;
        }

        public int Toggle(int was = 0)
        {
            if (was == 1)
                return 0;

            return 1;
        }
    }
}