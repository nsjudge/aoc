if (args.Length != 1)
{
    throw new ArgumentException();
}

var readings = new List<int>();
using (var reader = new StreamReader(args[0]))
{
    while (!reader.EndOfStream)
    {
        string? line = await reader.ReadLineAsync();
        if (!int.TryParse(line, out int depth))
        {
            continue;
        }

        readings.Add(depth);
    }
}

int deeper = 0;
for (int index = 1; index < readings.Count; ++index)
{
    if (readings[index] > readings[index - 1])
    {
        ++deeper;
    }
}

Console.WriteLine($"Count: {deeper}");
