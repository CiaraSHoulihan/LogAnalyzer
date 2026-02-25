using Microsoft.Extensions.DependencyInjection;
using LogAnalyzer.DI;
using LogAnalyzer;

var services = new ServiceCollection()
    .AddLogAnalyzer()
    .BuildServiceProvider();

try
{
    var app = services.GetRequiredService<LogAnalyzerApp>();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
