using Castle.Core;
using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void ManipulateLightsInMultipleRows()
        {
            //todo: I need tests for Off
            new Lights(new[,] {{0}}).TurnOnBetween(Lights.ZeroZero(), Coordinate(0, 0)).Should()
                .Be(new Lights(new[,] {{1}}));
            new Lights(new[,] {{0, 0}}).TurnOnBetween(Lights.ZeroZero(), Coordinate(0, 1)).Should()
                .Be(new Lights(new[,] {{1, 1}}));
            new Lights(new[,] {{0, 0, 0}}).TurnOnBetween(Lights.ZeroZero(), Coordinate(0, 2)).Should()
                .Be(new Lights(new[,] {{1, 1, 1}}));
            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(Lights.ZeroZero(), Coordinate(1, 1))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 0},
                    {1, 1, 0}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(Lights.ZeroZero(), Coordinate(1, 2))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 1},
                    {1, 1, 1}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0},
                    {1, 1, 0}
                }).TurnOnBetween(Lights.ZeroZero(), Coordinate(2, 1))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 0},
                    {1, 1, 0},
                    {1, 1, 0}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 1},
                    {1, 1, 0, 0}
                }).AllOn()
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1}
                }));
        }

        [Fact]
        public void Toggling()
        {
            new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 1},
                    {1, 1, 0, 0}
                }).ToggleBetween(Coordinate(1, 1), Coordinate(2, 3))
                .Should().Be(new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {1, 0, 1, 1}
                }));
        }

        [Fact]
        public void TestToString()
        {
            new Lights(new[,] {{1, 0, 1}}).ToString().Should().Be("1, 0, 1");
            new Lights(new[,] {{1, 0, 1}, {1, 0, 0}}).ToString().Should().Be("1, 0, 1\n1, 0, 0");
        }

        private static Pair<int, int> Coordinate(int first, int second)
        {
            return new Pair<int, int>(first, second);
        }
    }
}