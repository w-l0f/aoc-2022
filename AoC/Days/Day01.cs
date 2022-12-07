namespace AoC.Days;

public class Day01 : BaseDay, IDay
{
    public int GetDay()
        => 01;
    
    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var sums = GetSums(input);
        return sums.Max();
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var sums = GetSums(input);
        sums.Sort();
        return sums.ToArray()[^3..].Sum();
    }

    private static List<int> GetSums(string[] input)
    {
        var sums = input.Aggregate(new List<int>() { 0 },
            (agg, val) =>
            {
                if (string.IsNullOrEmpty(val))
                    agg.Add(0);
                else
                    agg[^1] += int.Parse(val);
                return agg;
            }, x => x);
        return sums;
    }
}