namespace Kata;

public class Coordinate
{
    public static readonly Coordinate ZeroZero = new(0, 0);

    private Coordinate(int row, int column)
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
}