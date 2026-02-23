using LogAnalyzer.Interfaces;
using LogAnalyzer.Core;

namespace LogAnalyzer;

public class LogAnalyzerApp
{
    private readonly IUserInputService _input;
    private readonly IHttpLogParser _parser;
    private readonly IReportPrinter _printer;

    public LogAnalyzerApp(
        IUserInputService input,
        IHttpLogParser parser,
        IReportPrinter printer)
    {
        _input = input;
        _parser = parser;
        _printer = printer;
    }

    public void Run()
    {
        while (true)
        {
            var filePath = _input.PromptForFilePath();
            if (filePath == null)
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                continue;
            }

            var stats = new LogStatistics();

            foreach (var line in File.ReadLines(filePath))
            {
                var entry = _parser.Parse(line);
                if (entry != null)
                    stats.Add(entry);
            }

            _printer.Print(stats);
        }
    }
}
