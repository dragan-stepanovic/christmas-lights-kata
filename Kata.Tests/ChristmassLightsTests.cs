using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TurningOn()
        {
            new Lights(new[,] {{0}}).TurnOnBetween(Coordinate.ZeroZero_ToRemove(), Coordinate.At_ToRemove(0, 0))
                .Should()
                .Be(new Lights(new[,] {{1}}));
            new Lights(new[,] {{0, 0}}).TurnOnBetween(Coordinate.ZeroZero_ToRemove(), Coordinate.At_ToRemove(0, 1))
                .Should()
                .Be(new Lights(new[,] {{1, 1}}));
            new Lights(new[,] {{0, 0, 0}}).TurnOnBetween(Coordinate.ZeroZero_ToRemove(), Coordinate.At_ToRemove(0, 2))
                .Should()
                .Be(new Lights(new[,] {{1, 1, 1}}));
            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(Coordinate.ZeroZero_ToRemove(), Coordinate.At_ToRemove(1, 1))
                .Should().Be(new Lights(new[,]
                {
                    {1, 1, 0},
                    {1, 1, 0}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).TurnOnBetween(Coordinate.ZeroZero_ToRemove(), Coordinate.At_ToRemove(1, 2))
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
                }).TurnOnBetween(Coordinate.ZeroZero_ToRemove(), Coordinate.At_ToRemove(2, 1))
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
                }).TurnOnBetween(Coordinate.ZeroZero_ToRemove(), Coordinate.At_ToRemove(2, 3))
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