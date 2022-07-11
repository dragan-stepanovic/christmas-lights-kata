using Castle.Core;

static internal class Coordinate
{
    public static Pair<int, int> At(int first, int second)
    {
        return new Pair<int, int>(first, second);
    }

    public static Pair<int, int> ZeroZero()
    {
        return Coordinate.At(0, 0);
    }
}