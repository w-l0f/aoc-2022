namespace AoC.Days;

public class Day07 : BaseDay, IDay
{
    public int GetDay()
        => 07;
    
    public object GetSolutionA(string fileName)
    {
        var input = GetInputLines(fileName);
        var rootItem = GetStructure(input);
        var flat = rootItem.GetFlatItemList();
        return flat.Where(x => x.IsDirectory && x.TotalSize <= 100000).Sum(x => x.TotalSize);
    }

    private Item GetStructure(string[] input)
    {
        var root = new Item()
        {
            Name = "root",
            ItemType = ItemType.Dir,
        };

        var current = root;
        foreach (var line in input[1..])
        {
            if (line == "$ ls")
            {
                // skip no-op
                continue;
            }
            
            if (line.StartsWith("$ cd "))
            {
                // directory change
                var cd = line.Split(" ").Last();
                if (cd == "..")
                    current = current.Parent!;
                else
                    current = current.Children.First(x => x.IsDirectory && x.Name == cd);
            }
            else
            {
                // file or dir data
                var newItem = line.Split(" ");
                long.TryParse(newItem[0], out var size);
                current.Children.Add( new Item()
                {
                    ItemType = newItem[0] == "dir" ? ItemType.Dir : ItemType.File,
                    Name = newItem[1],
                    Size = size,
                    Parent = current
                });
            }
        }

        return root;
    }

    public object GetSolutionB(string fileName)
    {
        var input = GetInputLines(fileName);
        var rootItem = GetStructure(input);
        var flat = rootItem.GetFlatItemList();

        var spaceNeeded = 30000000;
        var totalSpace = 70000000;
        var spaceFree = totalSpace - rootItem.TotalSize;
        var freeUp = spaceNeeded - spaceFree;

        return flat
            .Where(x => x.IsDirectory && x.TotalSize >= freeUp)
            .OrderBy(x => x.TotalSize)
            .First()
            .TotalSize;
    }

    private class Item
    {
        public string Name { get; set; } = "";
        public ItemType ItemType { get; set; }
        public long Size { get; set; }
        public List<Item> Children { get; set; } = new();
        public Item? Parent { get; set; }

        public bool IsDirectory => ItemType == ItemType.Dir;
        public long TotalSize => Size + Children.Sum(c => c.TotalSize);

        public List<Item> GetFlatItemList()
        {
            var flat = new List<Item>(Children);
            flat.AddRange(Children.SelectMany(c => c.GetFlatItemList()));
            return flat;
        }
    }
    
    private enum ItemType
    {
        File,
        Dir
    }
}