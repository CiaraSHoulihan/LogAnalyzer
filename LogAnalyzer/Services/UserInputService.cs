using LogAnalyzer.Interfaces;

namespace LogAnalyzer.Services;

class UserInputService : IUserInputService
{
    public string? PromptForFilePath()
    {
        while (true)
        {
            Console.Write("Enter the full path of the log file (or type 'exit' to quit): ");
            string? filePath = Console.ReadLine();

            if (filePath == null)
            {
                continue;
            }

            if (filePath.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Invalid file path. Try again.\n");
                continue;
            }

            return filePath;
        }
    }
}
