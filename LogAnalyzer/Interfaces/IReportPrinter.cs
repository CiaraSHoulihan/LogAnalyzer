using LogAnalyzer.Core;

namespace LogAnalyzer.Interfaces;

public interface IReportPrinter
{
    void Print(LogStatistics stats);
}