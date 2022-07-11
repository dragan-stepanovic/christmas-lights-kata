using System.Collections.Generic;
using System.Linq;

namespace Kata;

internal static class Coordinates
{
    public static List<Coordinate> Between(Coordinate bottomLeft, Coordinate topRight)
    {
        var range = new List<Coordinate>();
        foreach (var row in RowsBetween(bottomLeft, topRight))
            range.AddRange(ColumnsBetween(topRight.Column, bottomLeft)
                .Select(column => Coordinate.At(row, column)));

        // var range = new List<Coordinate>();
        // for (var row = bottomLeft.Row; row <= topRight.Row; row++)
        //     range.AddRange(ColumnsBetween(bottomLeft.Column, topRight.Column)
        //         .Select(column => Coordinate.At(row, column)));
        return range;
    }


    private static IEnumerable<int> RowsBetween(Coordinate bottomLeft, Coordinate topRight)
    {
        return NumbersBetween(bottomLeft.Row, topRight.Row);
    }

    private static IEnumerable<int> ColumnsBetween(int right, Coordinate bottomLeft)
    {
        return NumbersBetween(bottomLeft.Column, right);
    }

    private static IEnumerable<int> NumbersBetween(int left, int right)
    {
        return Enumerable.Range(left, DistanceBetween(left, right));
    }

    private static int DistanceBetween(int left, int right)
    {
        return right - left + 1;
    }
}