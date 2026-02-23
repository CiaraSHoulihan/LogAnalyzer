using LogAnalyzer.Models;

namespace LogAnalyzer.Core;

public class LogStatistics
{
    public HashSet<string> UniqueIps { get; } = new();
    public Dictionary<string, int> IpCount { get; } = new();
    public Dictionary<string, int> IpErrors { get; } = new();
    public Dictionary<string, int> UrlCount { get; } = new();

    public void Add(HttpLogEntry entry)
    {
        UniqueIps.Add(entry.IpAddress);

        if (!IpCount.ContainsKey(entry.IpAddress))
        {
            IpCount[entry.IpAddress] = 0;
        }
        IpCount[entry.IpAddress]++;

        if (entry.StatusCode >= 500 && entry.StatusCode < 600)
        {
            if (!IpErrors.ContainsKey(entry.IpAddress))
            {
                IpErrors[entry.IpAddress] = 0;
            }
            IpErrors[entry.IpAddress]++;
        }

        if (entry.Url != null)
        {
            if (!UrlCount.ContainsKey(entry.Url))
            {
                UrlCount[entry.Url] = 0;
            }
            UrlCount[entry.Url]++;
        }
    }

    public Dictionary<string, int> SuccessfulRequests =>
        IpCount.ToDictionary(
            kv => kv.Key,
            kv => kv.Value - (IpErrors.ContainsKey(kv.Key) ? IpErrors[kv.Key] : 0)
        );
}
