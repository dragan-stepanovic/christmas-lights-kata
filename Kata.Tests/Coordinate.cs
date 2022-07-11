using Castle.Core;

namespace Kata.Tests;

internal class Coordinate
{
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Column { get; }
    public int Row { get; }

    public static Pair<int, int> At(int first, int second)
    {
        return new Pair<int, int>(first, second);
    }

    public static Pair<int, int> ZeroZero()
    {
        return At(0, 0);
    }
}