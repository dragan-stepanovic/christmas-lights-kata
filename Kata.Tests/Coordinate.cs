using Castle.Core;

namespace Kata.Tests;

internal class Coordinate
{
    private readonly int _column;
    private readonly int _row;

    public Coordinate(int row, int column)
    {
        _row = row;
        _column = column;
    }

    public static Pair<int, int> At(int first, int second)
    {
        return new Pair<int, int>(first, second);
    }

    public static Pair<int, int> ZeroZero()
    {
        return At(0, 0);
    }
}