using System.Text.RegularExpressions;

Console.WriteLine(args.Length);
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

int aim = 0;
int horizontal = 0;
int depth = 0;
var regex = new Regex(@"^(forward|down|up)\s+(\d+)\s*$", RegexOptions.Compiled);
foreach (string line in lines)
{
    Match match = regex.Match(line);
    if (!match.Success)
    {
        continue;
    }

    var delta = int.Parse(match.Groups[2].Value);
    switch (match.Groups[1].Value)
    {
        case "forward":
        horizontal += delta;
        depth += aim * delta;
        break;

        case "down":
        aim += delta;
        break;

        case "up":
        aim -= delta;
        break;
    }
}

Console.WriteLine($"Horizontal: {horizontal}");
Console.WriteLine($"Depth: {depth}");
Console.WriteLine($"Combined: {horizontal * depth}");
