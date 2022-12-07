namespace AoC.Days;

public class Day06 : BaseDay, IDay
{
    public int GetDay()
        => 06;
    
    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var first = input.First();
        return GetIndexUntilDistinctCount(first, 4) + 1;
    }

    private int GetIndexUntilDistinctCount(string line, int numberOfChars)
    {
        for (int i = numberOfChars-1; i < line.Length; i++)
            if (line.Substring(i - (numberOfChars -1), numberOfChars).ToCharArray().Distinct().Count() == numberOfChars)
                return i;

        return -1;
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var first = input.First();
        return GetIndexUntilDistinctCount(first, 14) + 1;
    }

}