using LogAnalyzer;

var input = new UserInputService();

while (true)
{
    string? filePath = input.PromptForFilePath();
    if (filePath == null)
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    var lines = File.ReadLines(filePath);

    var stats = new LogStatistics();

    foreach (var line in lines)
    {
        var entry = HttpLogParser.Parse(line);
        if (entry != null)
        {
            stats.Add(entry);
        }
    }

    ReportPrinter.Print(stats);

    Console.Write("\nWould you like to process another file? (y/n): ");
    string? answer = Console.ReadLine();

    if (!string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    Console.WriteLine();
}
