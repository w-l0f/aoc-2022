using AoC.Days;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day1()
    {
        var day = new Day01();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(24000));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));

        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(45000));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }

    [Test]
    public void Day2()
    {
        var day = new Day02();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(15));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(12));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day3()
    {
        var day = new Day03();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(157));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(70));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day4()
    {
        var day = new Day04();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(2));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(4));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day5()
    {
        var day = new Day05();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo("CMZ"));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo("MCD"));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day6()
    {
        var day = new Day06();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(11));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(26));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
    
    [Test]
    public void Day7()
    {
        var day = new Day07();
        Assert.That(day.GetSolutionA($"{day.GetDay():00}e.txt"), Is.EqualTo(95437));
        TestContext.WriteLine($"Solution {day.GetDay()}A:" + day.GetSolutionA($"{day.GetDay():00}.txt"));
        
        Assert.That(day.GetSolutionB($"{day.GetDay():00}e.txt"), Is.EqualTo(24933642));
        TestContext.WriteLine($"Solution {day.GetDay()}B:" + day.GetSolutionB($"{day.GetDay():00}.txt"));
    }
}