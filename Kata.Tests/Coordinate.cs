using Castle.Core;

namespace Kata.Tests;

internal static class Coordinate
{
    public static Pair<int, int> At(int first, int second)
    {
        return new Pair<int, int>(first, second);
    }

    public static Pair<int, int> ZeroZero()
    {
        return At(0, 0);
    }
}