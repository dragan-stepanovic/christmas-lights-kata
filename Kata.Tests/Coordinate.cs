using Castle.Core;

namespace Kata.Tests;

public class Coordinate
{
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Column { get; }
    public int Row { get; }

    public static Coordinate At(int row, int column)
    {
        return new Coordinate(row, column);
    }

    public static Pair<int, int> ZeroZero_ToRemove()
    {
        return At_ToRemove(0, 0);
    }

    public static Pair<int, int> At_ToRemove(int first, int second)
    {
        return new Pair<int, int>(first, second);
    }

    public static Coordinate ZeroZero()
    {
        return Coordinate.At(0, 0);
    }
}