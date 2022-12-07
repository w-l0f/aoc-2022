using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AoC.Days;

public class Day05 : BaseDay, IDay
{
    public int GetDay()
        => 05;

    public object GetSolutionA(string fileName)
    {
        var input = new Stack<string>(GetInputLines(fileName).Reverse());
        var stacks = GetInitialStacks(ref input);
        
        while (input.Any())
        {
            var line = input.Pop();
            // move 1 from 2 to 1
            var inst = Regex
                .Split(line, @"\D+")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => int.Parse(x))
                .ToArray();
            int i = 0;
            while (i++ < inst[0])
            {
                var val = stacks[inst[1] - 1].Pop();
                stacks[inst[2]-1].Push(val);
            }
        }
        
        return stacks.Where(s => s.Count > 0)
            .Aggregate("", (current, s) => current + s.Pop());
    }

    private Stack<char>[] GetInitialStacks(ref Stack<string> input)
    {
        var line = input.Pop();
        var stacks = new Stack<char>[(line.Length+1) / 4];
        
        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<char>();
        }
        
        while (!string.IsNullOrWhiteSpace(line))
        {
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (char.IsWhiteSpace(c) || c == '[' || c == ']' || char.IsDigit(c))
                    continue;
                var ix = i / 4;
                stacks[ix].Push(c);
            }

            line = input.Pop();
        }
        
        for (var i = 0; i < stacks.Length; i++)
        {
            // reverse
            stacks[i] = new Stack<char>(stacks[i]);
        }

        return stacks;
    }

    public object GetSolutionB(string fileName)
    {
        var input = new Stack<string>(GetInputLines(fileName).Reverse());
        var stacks = GetInitialStacks(ref input);
        
        while (input.Any())
        {
            var line = input.Pop();
            var inst = Regex
                .Split(line, @"\D+")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(int.Parse)
                .ToArray();
            //move 1 from 2 to 1
            var i = 0;
            var tmp = new Stack<char>();
            while (i++ < inst[0])
            {
                var val = stacks[inst[1] - 1].Pop();
                tmp.Push(val);
            }

            while (tmp.Any())
            {
                stacks[inst[2]-1].Push(tmp.Pop());
            }

        }
        
        return stacks.Where(s => s.Count > 0)
            .Aggregate("", (current, s) => current + s.Pop());
    }
}