using System.Drawing;

namespace AoC.Days;

public class Day10 : BaseDay, IDay
{
    public int GetDay()
        => 10;


    public object GetSolutionA(string fileName)
    {
        // 20th, 60th, 100th, 140th, 180th, and 220th cycles
        var cycles = new List<int>(){20,60,100,140,180,220};
        
        var input = GetInputLines(fileName);
        var cycle = 1;
        var x = 1;
        var strength = 0;
        foreach (var line in input)
        {
            cycle++;
            checkCycles();
            if (line.StartsWith("addx"))
            {
                x += int.Parse(line.Split(" ")[1]);
                cycle++;
                checkCycles();
            }
        }
        return strength;
        
        void checkCycles()
        {
            if (cycle != cycles.FirstOrDefault()) return;
            strength += cycles.First() * x;
            cycles.RemoveAt(0);
        }
    }
    

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);

        var cycle = 1;
        var x = 1;
        var pixels = "";
        draw();
        foreach (var line in input)
        {
            draw();
            cycle++;
            if (line.StartsWith("addx"))
            {
                x += int.Parse(line.Split(" ")[1]);
                draw();
                cycle++;
            }
        }

        return "\n"+string.Join("\n", pixels
            .Chunk(40)
            .Select(l => new string(l)));
        
        void draw()
        {
            if(Math.Abs(x - (cycle % 40)) < 2)
            {
                pixels += "#";
            }
            else
            {
                pixels += ".";
            }
        }
    }
}