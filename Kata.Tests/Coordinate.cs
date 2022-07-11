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

    public static Coordinate At(Pair<int, int> bottomLeft)
    {
        return new Coordinate(bottomLeft.First, bottomLeft.Second);
    }

    public static Pair<int, int> ZeroZero()
    {
        return At_ToRemove(0, 0);
    }

    public static Pair<int, int> At_ToRemove(int first, int second)
    {
        return new Pair<int, int>(first, second);
    }
}