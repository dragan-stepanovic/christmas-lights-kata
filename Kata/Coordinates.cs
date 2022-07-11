using System.Collections.Generic;
using System.Linq;

namespace Kata;

internal static class Coordinates
{
    public static List<Coordinate> Between(Coordinate bottomLeft, Coordinate topRight)
    {
        var range = new List<Coordinate>();
        for (var row = bottomLeft.Row; row <= topRight.Row; row++)
            range.AddRange(ColumnsBetween(bottomLeft.Column, topRight.Column)
                .Select(column => Coordinate.At(row, column)));
        return range;
    }

    private static IEnumerable<int> ColumnsBetween(int leftColumn, int rightColumn)
    {
        return Enumerable.Range(leftColumn, rightColumn - leftColumn + 1);
    }
}