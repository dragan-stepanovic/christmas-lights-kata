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
            new Lights(new[,] {{0}}).TurnOnBetween(Coordinate.ZeroZero, Coordinate.ZeroZero)
                .Should()
                .Be(new Lights(new[,] {{1}}));
            Pair<int, int> bottomLeft1 = Coordinate.ZeroZero_ToRemove();
            Pair<int, int> topRight1 = Coordinate.At_ToRemove(0, 1);
            new Lights(new[,] {{0, 0}}).TurnOnBetween(new Coordinate(bottomLeft1.First, bottomLeft1.Second),
                    new Coordinate(topRight1.First, topRight1.Second))
                .Should()
                .Be(new Lights(new[,] {{1, 1}}));
            Pair<int, int> bottomLeft2 = Coordinate.ZeroZero_ToRemove();
            Pair<int, int> topRight2 = Coordinate.At_ToRemove(0, 2);
            new Lights(new[,] {{0, 0, 0}}).TurnOnBetween(new Coordinate(bottomLeft2.First, bottomLeft2.Second),
                    new Coordinate(topRight2.First, topRight2.Second))
                .Should()
                .Be(new Lights(new[,] {{1, 1, 1}}));
            Pair<int, int> bottomLeft3 = Coordinate.ZeroZero_ToRemove();
            Pair<int, int> topRight3 = Coordinate.At_ToRemove(1, 1);
            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(new Coordinate(bottomLeft3.First, bottomLeft3.Second),
                    new Coordinate(topRight3.First, topRight3.Second))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 0},
                    {1, 1, 0}
                }));

            Pair<int, int> bottomLeft4 = Coordinate.ZeroZero_ToRemove();
            Pair<int, int> topRight4 = Coordinate.At_ToRemove(1, 2);
            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(new Coordinate(bottomLeft4.First, bottomLeft4.Second),
                    new Coordinate(topRight4.First, topRight4.Second))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 1},
                    {1, 1, 1}
                }));

            Pair<int, int> bottomLeft5 = Coordinate.ZeroZero_ToRemove();
            Pair<int, int> topRight5 = Coordinate.At_ToRemove(2, 1);
            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0},
                    {1, 1, 0}
                }).TurnOnBetween(new Coordinate(bottomLeft5.First, bottomLeft5.Second),
                    new Coordinate(topRight5.First, topRight5.Second))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 0},
                    {1, 1, 0},
                    {1, 1, 0}
                }));

            Pair<int, int> bottomLeft6 = Coordinate.ZeroZero_ToRemove();
            Pair<int, int> topRight6 = Coordinate.At_ToRemove(2, 3);
            new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 1},
                    {1, 1, 0, 0}
                }).TurnOnBetween(new Coordinate(bottomLeft6.First, bottomLeft6.Second),
                    new Coordinate(topRight6.First, topRight6.Second))
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
            new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 1},
                    {1, 1, 0, 0}
                }).TurnOffBetween(Coordinate.At(1, 1), Coordinate.At(2, 3))
                .Should().Be(new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 0, 0, 0}
                }));

            new Lights(new[,]
                {
                    {0, 0, 1, 0},
                    {1, 1, 0, 1},
                    {1, 1, 0, 1}
                }).TurnOffBetween(Coordinate.ZeroZero, Coordinate.At(2, 3))
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
                }).ToggleBetween(Coordinate.At(1, 1), Coordinate.At(2, 3))
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