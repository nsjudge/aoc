if (args.Length != 1)
{
    throw new ArgumentException();
}

var lines = new List<string>();
using (var reader = new StreamReader(args[0]))
{
    while (!reader.EndOfStream)
    {
        string? line = await reader.ReadLineAsync();
        if (string.IsNullOrEmpty(line))
        {
            continue;
        }
    
        lines.Add(line);
    }
}

List<string> candidates = lines;
int index = 0;
while (candidates.Count > 1)
{
    bits count = bits.count(candidates, index);
    bool ones = count.ones >= count.zeros;
    candidates = candidates.Where(l => ones ? l[index] == '1' : l[index] == '0').ToList();
    ++index;
}

int oxygen = BinaryToInt(candidates.ElementAt(0));

candidates = lines;
index = 0;
while (candidates.Count > 1)
{
    bits count = bits.count(candidates, index);
    bool zeros = count.zeros <= count.ones;
    candidates = candidates.Where(l => zeros ? l[index] == '0' : l[index] == '1').ToList();
    ++index;
}

int co2 = BinaryToInt(candidates.ElementAt(0));

Console.WriteLine($"oxygen: {oxygen}");
Console.WriteLine($"co2: {co2}");
Console.WriteLine($"life: {oxygen * co2}");

int BinaryToInt(string binary)
{
    int val = 0;
    foreach (char bit in binary)
    {
        if ((bit != '0') && (bit != '1'))
        {
            continue;
        }

        val <<= 1;
        if (bit == '1')
        {
            val |= 1;
        }
    }

    return val;
}

class bits
{
    public int zeros;
    public int ones;

    public static bits count(IEnumerable<string> candidates, int index)
    {
        var counts = new bits();
        foreach (string test in candidates)
        {
            if (test[index] == '1')
            {
                ++counts.ones;
            }
            else
            {
                ++counts.zeros;
            }
        }

        return counts;
    }
}

