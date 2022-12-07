using System.Diagnostics;

namespace AoC.Days;

public class Day02 : BaseDay, IDay
{
    public int GetDay()
        => 02;

    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var score = 0;
        foreach (var line in input)
        {
            var me = GetPlay(line[2]);
            var him = GetPlay(line[0]);
            score += GetScore(me, him) + (int)me;
        }

        return score;
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var score = 0;
        foreach (var line in input)
        {
            var act = line[2];
            var him = GetPlay(line[0]);
            score += GetScore(him, act);
        }

        return score;
    }
    
    enum RPS
    {
        ROCK = 1,
        PAPER = 2,
        SCISSOR = 3
    }

    private RPS GetPlay(char c)
        => c switch
        {
            'A' => RPS.ROCK,
            'B' => RPS.PAPER,
            'C' => RPS.SCISSOR,
            'X' => RPS.ROCK,
            'Y' => RPS.PAPER,
            'Z' => RPS.SCISSOR
        };

    private int GetScore(RPS me, RPS his)
    {
        if (me == his)
            return 3;
        
        return (me, his) switch
        {
            (RPS.ROCK, RPS.SCISSOR) => 6,
            (RPS.ROCK, RPS.PAPER) => 0,
            (RPS.PAPER, RPS.ROCK) => 6,
            (RPS.PAPER, RPS.SCISSOR) => 0,
            (RPS.SCISSOR, RPS.PAPER) => 6,
            (RPS.SCISSOR, RPS.ROCK) => 0,
        };
    }
    
    private int GetScore(RPS his, char x)
    {
        return (his, x) switch
        {
            (RPS.ROCK, 'X') => 0 + (int)RPS.SCISSOR,
            (RPS.PAPER, 'X') => 0 + (int)RPS.ROCK,
            (RPS.SCISSOR, 'X') => 0 + (int)RPS.PAPER,
            (RPS.ROCK, 'Y') => 3 + (int)RPS.ROCK,
            (RPS.PAPER, 'Y') => 3 + (int)RPS.PAPER,
            (RPS.SCISSOR, 'Y') => 3 + (int)RPS.SCISSOR,
            (RPS.ROCK, 'Z') => 6 + (int)RPS.PAPER,
            (RPS.PAPER, 'Z') => 6 + (int)RPS.SCISSOR,
            (RPS.SCISSOR, 'Z') => 6 + (int)RPS.ROCK,
        };
    }
}