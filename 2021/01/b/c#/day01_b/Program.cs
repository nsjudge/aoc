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

var windows = new List<int>();
for (int index = 2; index < readings.Count; ++index)
{
    windows.Add(readings[index - 2] + readings[index - 1] + readings[index]);
}

int deeper = 0;
for (int index = 1; index < windows.Count; ++index)
{
    if (windows[index] > windows[index - 1])
    {
        ++deeper;
    }
}

Console.WriteLine($"Count: {deeper}");
