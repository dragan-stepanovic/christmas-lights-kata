using Castle.Core;
using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurningOn()
        {
            new Lights(new[,] {{0}}).TurnOnBetween(Coordinate.ZeroZero(), Coordinate.At_ToRemove(0, 0)).Should()
                .Be(new Lights(new[,] {{1}}));
            new Lights(new[,] {{0, 0}}).TurnOnBetween(Coordinate.ZeroZero(), Coordinate.At_ToRemove(0, 1)).Should()
                .Be(new Lights(new[,] {{1, 1}}));
            new Lights(new[,] {{0, 0, 0}}).TurnOnBetween(Coordinate.ZeroZero(), Coordinate.At_ToRemove(0, 2)).Should()
                .Be(new Lights(new[,] {{1, 1, 1}}));
            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(Coordinate.ZeroZero(), Coordinate.At_ToRemove(1, 1))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 0},
                    {1, 1, 0}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(Coordinate.ZeroZero(), Coordinate.At_ToRemove(1, 2))
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
                }).TurnOnBetween(Coordinate.ZeroZero(), Coordinate.At_ToRemove(2, 1))
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
                }).TurnOnBetween(Coordinate.ZeroZero(), Coordinate.At_ToRemove(2, 3))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1}
                }));
        }

        [Fact]
        public void TurningOff()
        {
            Pair<int, int> bottomLeft = Coordinate.At_ToRemove(1, 1);
            Pair<int, int> topRight = Coordinate.At_ToRemove(2, 3);
            new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 1},
                    {1, 1, 0, 0}
                }).TurnOffBetween(Coordinate.At(bottomLeft.First, bottomLeft.Second),
                    Coordinate.At(topRight.First, topRight.Second))
                .Should().Be(new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 0, 0, 0}
                }));

            Pair<int, int> bottomLeft1 = Coordinate.ZeroZero();
            Pair<int, int> topRight1 = Coordinate.At_ToRemove(2, 3);
            new Lights(new[,]
                {
                    {0, 0, 1, 0},
                    {1, 1, 0, 1},
                    {1, 1, 0, 1}
                }).TurnOffBetween(Coordinate.At(bottomLeft1.First, bottomLeft1.Second),
                    Coordinate.At(topRight1.First, topRight1.Second))
                .Should().Be(new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0}
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
                }).ToggleBetween(Coordinate.At_ToRemove(1, 1), Coordinate.At_ToRemove(2, 3))
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
    }
}