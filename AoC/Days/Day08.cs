namespace AoC.Days;

public class Day08 : BaseDay, IDay
{
    public int GetDay()
        => 08;
    
    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);

        var visible = new int[input.Length, input[0].Length];
        for (var i = 1; i < input.Length-1; i++)
        {
            var line = input[i];
            var lineCount = 0;
            for (var y = 1; y < input[i].Length-1; y++)
            {
                var row = new string(input.Select(x => x[y]).ToArray());
                var leftMax = line[..y].Select(char.GetNumericValue).Max();
                var rightMax = line[(y+1)..].Select(char.GetNumericValue).Max();
                var topMax = row[..i].Select(char.GetNumericValue).Max();
                var bottomMax = row[(i+1)..].Select(char.GetNumericValue).Max();
                if (char.GetNumericValue(input[i][y]) > new[] { leftMax, rightMax, topMax, bottomMax }.Min())
                {
                    visible[i, y] = 1;
                    lineCount++;
                }
            }
        }

        var edgesSum = input.Length * 4 - 4;
        var innerSum = visible.Cast<int>().Sum();
        return edgesSum + innerSum;
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);

        var visible = new int[input.Length, input[0].Length];
        for (var i = 1; i < input.Length-1; i++)
        {
            var line = input[i];
            for (var y = 1; y < input[i].Length-1; y++)
            {
                var height = char.GetNumericValue(input[i][y]);
                var row = new string(input.Select(x => x[y]).ToArray());
                var leftLine = line[..y].Select(char.GetNumericValue).Reverse().ToArray();
                var rightLine = line[(y+1)..].Select(char.GetNumericValue).ToArray();
                var topLine = row[..i].Select(char.GetNumericValue).Reverse().ToArray();
                var bottomLine = row[(i+1)..].Select(char.GetNumericValue).ToArray();
                var trees = getVisibleTrees(leftLine);
                trees *= getVisibleTrees(rightLine);
                trees *= getVisibleTrees(topLine);
                trees *= getVisibleTrees(bottomLine);
                visible[i, y] = trees;
                
                int getVisibleTrees(IEnumerable<double> trees)
                {
                    var count = 0;
                    foreach (var tree in trees)
                    {
                        count++;
                        if (tree >= height)
                            break;
                    }

                    return count;
                }
                
            }
        }

        return visible.Cast<int>().Max();
    }
}