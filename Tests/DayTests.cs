using AoC.Days;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day01()
    {
        var day = new Day01();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(24000));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));

        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(45000));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }

    [Test]
    public void Day02()
    {
        var day = new Day02();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(15));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(12));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day03()
    {
        var day = new Day03();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(157));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(70));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day04()
    {
        var day = new Day04();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(2));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(4));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day05()
    {
        var day = new Day05();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo("CMZ"));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo("MCD"));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day06()
    {
        var day = new Day06();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(11));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(26));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day07()
    {
        var day = new Day07();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(95437));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(24933642));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day08()
    {
        var day = new Day08();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(21));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(8));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day09()
    {
        var day = new Day09();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(13));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e2.txt"), Is.EqualTo(36));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day10()
    {
        var day = new Day10();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(13140));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));

        var exampleSolution = @"
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......######";
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(exampleSolution));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day11()
    {
        var day = new Day11();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(10605));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(2713310158));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
}