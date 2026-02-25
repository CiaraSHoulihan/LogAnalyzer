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

    var stats = new LogStatistics();

    try
    {
        var lines = File.ReadLines(filePath);

        foreach (var line in lines)
        {
            var entry = HttpLogParser.Parse(line);
            if (entry != null)
            {
                stats.Add(entry);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to process file: {ex.Message}\n");
        continue; // let the user try again
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
