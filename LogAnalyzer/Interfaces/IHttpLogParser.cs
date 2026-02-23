using LogAnalyzer.Models;

namespace LogAnalyzer.Interfaces;

public interface IHttpLogParser
{
    HttpLogEntry? Parse(string line);
}
