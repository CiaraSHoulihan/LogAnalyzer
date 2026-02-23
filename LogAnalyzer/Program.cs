using Microsoft.Extensions.DependencyInjection;
using LogAnalyzer.DI;
using LogAnalyzer;

var services = new ServiceCollection()
    .AddLogAnalyzer()
    .BuildServiceProvider();

var app = services.GetRequiredService<LogAnalyzerApp>();
app.Run();