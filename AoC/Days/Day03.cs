using System.Diagnostics;

namespace AoC.Days;

public class Day03 : BaseDay, IDay
{
    public int GetDay()
        => 03;

    private string prios = "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var prio = 0;
        foreach (var line in input)
        {
            var firstHalf = line
                .Take(line.Length / 2)
                .ToHashSet();
            for (var i = line.Length / 2; true; i++)
            {
                if (!firstHalf.Contains(line[i])) continue;
                prio += prios.IndexOf(line[i]);
                break;
            }
        }

        return prio;
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var prio = 0;
        
        foreach (var elfs in input.Chunk(3))
        {
            var hashsets = elfs[^2..].Select(x => x.ToHashSet());
            var common = elfs[0].First(c => hashsets.All(x => x.Contains(c)));
            prio += prios.IndexOf(common);
        }

        return prio;
    }
    
}