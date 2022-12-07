namespace AoC;

public abstract class BaseDay 
{
    public string[] GetInputLines(string fileName)
        => File.ReadLines($"Inputs/{fileName}").ToArray();
}