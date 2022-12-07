using System.Diagnostics;

namespace AoC.Days;

public class Day04 : BaseDay, IDay
{
    public int GetDay()
        => 04;

    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var count = 0;
        foreach (var line in input)
        {
            var nums = line
                .Split(',')
                .SelectMany(x => x.Split('-'))
                .Select(x => int.Parse(x))
                .ToArray();

            if (Contained(nums[0], nums[1], nums[2], nums[3])
                || Contained(nums[2], nums[3], nums[0], nums[1]))
            {
                count++;
            }
        }

        return count;
    }

    private bool Contained(int x1, int y1, int x2, int y2)
        => x1 <= x2 && y1 >= y2;
    
    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var count = 0;
        foreach (var line in input)
        {
            var nums = line
                .Split(',')
                .SelectMany(x => x.Split('-'))
                .Select(x => int.Parse(x))
                .ToArray();

            if (Intersect(nums[0], nums[1], nums[2], nums[3])
                || Intersect(nums[2], nums[3], nums[0], nums[1]))
            {
                count++;
            }
        }

        return count;
    }
    
    private bool Intersect(int x1, int y1, int x2, int y2)
        => (x1 <= x2 && y1 >= y2)
           || (x1 <= x2 && y1 >= x2)
           || (x1 <= y2 && y1 >= y2);
}