using Castle.Core;
using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void ManipulatesNLightsInTheSameRow()
        {
            Lights(0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1));
            Lights(0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).AllOff().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0).ToggleAll().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).ToggleAll().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1));
            Lights(1, 1, 1).AllOff().Should().Be(Lights(0, 0, 0));
            Lights(0, 0, 0, 0, 0).AllOn().Should().Be(Lights(1, 1, 1, 1, 1));
        }

        [Fact]
        public void ManipulateIndividualLightsInTheSameRow()
        {
            Lights(0, 0).On(new[] {1, 1}).Should().Be(Lights(0, 1));
            Lights(0, 0).On(new[] {0, 0}).Should().Be(Lights(1, 0));
            Lights(0, 0).On(new[] {0, 1}).Should().Be(Lights(1, 1));
            Lights(0, 0, 0).On(new[] {0, 1}).Should().Be(Lights(1, 1, 0));
            Lights(0, 0, 0, 0).On(new[] {1, 2}).Should().Be(Lights(0, 1, 1, 0));
            Lights(0, 1, 0, 1).On(new[] {1, 2}).Should().Be(Lights(0, 1, 1, 1));
            Lights(0, 1, 0, 1).On(new[] {0, 3}).Should().Be(Lights(1, 1, 1, 1));

            Lights(1, 1).Off(new[] {1, 1}).Should().Be(Lights(1, 0));
            Lights(1, 1).Off(new[] {0, 1}).Should().Be(Lights(0, 0));
            Lights(1, 1, 1).Off(new[] {2, 2}).Should().Be(Lights(1, 1, 0));
            Lights(1, 1, 1).Off(new[] {0, 2}).Should().Be(Lights(0, 0, 0));
            Lights(0, 1, 0, 1).Off(new[] {0, 3}).Should().Be(Lights(0, 0, 0, 0));
            Lights(0, 1, 0, 1).Off(new[] {1, 2}).Should().Be(Lights(0, 0, 0, 1));
        }

        [Fact]
        public void ManipulateAllLightsInMultipleRows()
        {
            new Lights(new[,] {{0}}).On(new[] {0, 0}).Should().Be(new Lights(new[,] {{1}}));
            new Lights(new[,] {{0, 0}}).On(new[] {0, 1}).Should().Be(new Lights(new[,] {{1, 1}}));
            new Lights(new[,] {{0, 0, 0}}).On(new[] {0, 2}).Should().Be(new Lights(new[,] {{1, 1, 1}}));
            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).On(new Pair<int, int>(1, 1)).Should()
                .Be(new Lights(new[,]
                {
                    {1, 1, 0},
                    {1, 1, 0}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0}
                }).On(new Pair<int, int>(1, 2)).Should()
                .Be(new Lights(new[,]
                {
                    {1, 1, 1},
                    {1, 1, 1}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0},
                    {1, 1, 0}
                }).On(new Pair<int, int>(2, 1)).Should()
                .Be(new Lights(new[,]
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
                }).AllOn().Should()
                .Be(new Lights(new[,]
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1}
                }));

            new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 1},
                    {1, 1, 0, 0}
                }).Toggle(new Pair<int, int>(1, 1), new Pair<int, int>(2, 3)).Should()
                .Be(new Lights(new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {1, 0, 1, 1}
                }));
        }

        // [Fact]
        // public void FinalTest()
        // {
        //     const int maxSize = 1000000;
        //     var grid = new int[maxSize, maxSize];
        //     for (var i = 0; i < maxSize; i++)
        //     for (var j = 0; j < maxSize; j++)
        //         grid[i, j] = 0;
        // }

        [Fact]
        public void TestToString()
        {
            new Lights(new[,] {{1, 0, 1}}).ToString().Should().Be("1, 0, 1");
            new Lights(new[,] {{1, 0, 1}, {1, 0, 0}}).ToString().Should().Be("1, 0, 1\n1, 0, 0");
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