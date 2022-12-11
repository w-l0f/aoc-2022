namespace AoC.Days;

public class Day11 : BaseDay, IDay
{
    public int GetDay()
        => 11;

    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var monkeys = ParseMonkeys(input);
        for (var i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Any())
                {
                    var (toMonkey, toPass) = monkey.GetNextMonkey();
                    monkeys[toMonkey].Items.Add(toPass);
                }
            }
        }

        monkeys = monkeys
            .OrderByDescending(x => x.Business)
            .ToArray();

        return monkeys[0].Business * monkeys[1].Business;
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var monkeys = ParseMonkeys(input);
        for (var i = 0; i < 10000; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Any())
                {
                    var (toMonkey, toPass) = monkey.GetNextMonkey(relief: false);
                    monkeys[toMonkey].Items.Add(toPass);
                }
            }
        }

        monkeys = monkeys
            .OrderByDescending(x => x.Business)
            .ToArray();

        return monkeys[0].Business * monkeys[1].Business;
    }

    private Monkey[] ParseMonkeys(string[] input)
    {
        var monkeys = new List<Monkey>();
        var current = new Monkey();
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var s = line.Trim().Split(" ");
            if (s[0] == "Starting")
            {
                current.Items = s[2..]
                    .Select(x => long.Parse(x.Replace(",", "")))
                    .ToList();
            }

            if (s[0] == "Operation:")
            {
                var a = s[3];
                var op = s[4];
                var b = s[5];
                current.Operation = (a, op, b) switch
                {
                    ("old", "*", "old") => i => i * i,
                    ("old", "*", b: _) => i => i * long.Parse(b),
                    ("old", "+", "old") => i => i + i,
                    ("old", "+", b: _) => i => i + long.Parse(b),
                };
            }

            if (s[0] == "Test:")
            {
                current.TestMod = long.Parse(s[3]);
            }

            if (s[1] == "true:")
            {
                current.TestTrue = int.Parse(s[5]);
            }

            if (s[1] == "false:")
            {
                current.TestFalse = int.Parse(s[5]);
                monkeys.Add(current);
                current = new Monkey();
            }
        }

        var commonDivider = monkeys
            .Select(x => x.TestMod)
            .Aggregate((m, val) => m * val / gcd(m, val));
        long gcd(long n1, long n2)
            => n2 == 0
                ? n1
                : gcd(n2, n1 % n2);
        monkeys.ForEach(m => m.CommonDivider = commonDivider);
        return monkeys.ToArray();
    }
    
    private class Monkey
    {
        public List<long> Items = new();

        public Func<long, long> Operation;
        public long CommonDivider = 1;

        public (int monkey, long toPass) GetNextMonkey(bool relief = true)
        {
            var worryness = Items[0];
            Items.RemoveAt(0);
            Business++;
            var newWorryness = Operation(worryness);
            if (relief)
                newWorryness /= 3;
            newWorryness %= CommonDivider;
            return (newWorryness % TestMod == 0
                ? TestTrue
                : TestFalse, newWorryness);
        }

        public long TestMod;
        public int TestTrue;
        public int TestFalse;
        public long Business;
    }
}