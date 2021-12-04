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

var counts = new List<bits>();
foreach (string line in lines)
{
    int pos = 0;
    foreach (char bit in line)
    {
        if ((bit != '0') && (bit != '1'))
        {
            continue;
        }

        if (counts.Count <= pos)
        {
            counts.Add(new bits());
        }

        bits count = counts[pos++];
        if (bit == '0')
        {
            ++count.zeros;
        }
        else
        {
            ++count.ones;
        }
    }
}

int epsilon = 0;
int gamma = 0;
foreach (bits count in counts)
{
    epsilon <<= 1;
    gamma <<= 1;
    if (count.ones > count.zeros)
    {
        gamma |= 1;
    }
    else
    {
        epsilon |= 1;
    }
}

Console.WriteLine($"gamma: {gamma}");
Console.WriteLine($"epsilon: {epsilon}");
Console.WriteLine($"power: {gamma * epsilon}");

class bits
{
    public int zeros;
    public int ones;
}
