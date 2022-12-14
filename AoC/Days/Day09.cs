using System.Drawing;

namespace AoC.Days;

public class Day09 : BaseDay, IDay
{
    public int GetDay()
        => 09;

    private readonly Dictionary<string, Point> _directions = new Dictionary<string, Point>()
    {
        { "R", new Point(1, 0) },
        { "L", new Point(-1, 0) },
        { "U", new Point(0, 1) },
        { "D", new Point(0, -1) },
    };

    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var head = new Point();
        var tail = new Point();
        var v = new HashSet<Point> { new() };
        foreach (var line in input)
        {
            var split = line.Split(" ");
            var direction = split[0];
            var count = int.Parse(split[1]);
            for (var i = 0; i < count; i++)
            {
                head.Offset(_directions[direction]);

                if (Math.Abs(head.X - tail.X) <= 1 && Math.Abs(head.Y - tail.Y) <= 1)
                    continue;

                tail.Offset(GetMovement(head.X, tail.X), GetMovement(head.Y, tail.Y));

                int GetMovement(int v1, int v2)
                    => (v1, v2) switch
                    {
                        var (x, y) when (x > y) => 1,
                        var (x, y) when (x < y) => -1,
                        _ => 0
                    };

                v.Add(tail);
            }
        }

        return v.Count;
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var rope = new Point[10];
        Array.Fill(rope, new Point());
        var v = new HashSet<Point> { new() };
        foreach (var line in input)
        {
            var split = line.Split(" ");
            var direction = split[0];
            var count = int.Parse(split[1]);
            for (var i = 0; i < count; i++)
            {
                rope[0].Offset(_directions[direction]);

                for (var j = 1; j < rope.Length; j++)
                {
                    if (Math.Abs(rope[j].X - rope[j - 1].X) <= 1 && Math.Abs(rope[j].Y - rope[j - 1].Y) <= 1)
                        continue;

                    rope[j].Offset(GetMovement(rope[j - 1].X, rope[j].X), GetMovement(rope[j - 1].Y, rope[j].Y));

                    int GetMovement(int v1, int v2)
                        => (v1, v2) switch
                        {
                            var (x, y) when (x > y) => 1,
                            var (x, y) when (x < y) => -1,
                            _ => 0
                        };
                }

                v.Add(rope[9]);
            }
        }

        return v.Count;
    }
}