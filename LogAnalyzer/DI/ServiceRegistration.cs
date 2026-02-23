using Microsoft.Extensions.DependencyInjection;
using LogAnalyzer.Interfaces;
using LogAnalyzer.Services;

namespace LogAnalyzer.DI;

public static class ServiceRegistration
{
    public static IServiceCollection AddLogAnalyzer(this IServiceCollection services)
    {
        services.AddSingleton<IHttpLogParser, HttpLogParser>();
        services.AddSingleton<IUserInputService, UserInputService>();
        services.AddSingleton<IReportPrinter, ReportPrinter>();

        services.AddTransient<LogAnalyzerApp>();

        return services;
    }
}
