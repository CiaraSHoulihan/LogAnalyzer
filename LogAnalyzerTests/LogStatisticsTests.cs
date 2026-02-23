using LogAnalyzer.Core;
using LogAnalyzer.Models;

namespace LogAnalyzer.Tests;

public class LogStatisticsTests
{
    [Fact]
    public void Add_TracksUniqueIps()
    {
        var stats = new LogStatistics();

        stats.Add(new HttpLogEntry { IpAddress = "1.1.1.1", Url = "/a", StatusCode = 200 });
        stats.Add(new HttpLogEntry { IpAddress = "2.2.2.2", Url = "/b", StatusCode = 200 });

        Assert.Equal(2, stats.UniqueIps.Count);
    }

    [Fact]
    public void Add_TracksUrlCounts()
    {
        var stats = new LogStatistics();

        stats.Add(new HttpLogEntry { IpAddress = "1.1.1.1", Url = "/a", StatusCode = 200 });
        stats.Add(new HttpLogEntry { IpAddress = "2.2.2.2", Url = "/a", StatusCode = 200 });

        Assert.Equal(2, stats.UrlCount["/a"]);
    }

    [Fact]
    public void Add_TracksErrorCounts()
    {
        var stats = new LogStatistics();

        stats.Add(new HttpLogEntry { IpAddress = "1.1.1.1", Url = "/a", StatusCode = 500 });
        stats.Add(new HttpLogEntry { IpAddress = "1.1.1.1", Url = "/a", StatusCode = 200 });

        Assert.Equal(1, stats.IpErrors["1.1.1.1"]);
    }

    [Fact]
    public void SuccessfulRequests_ComputesCorrectly()
    {
        var stats = new LogStatistics();

        stats.Add(new HttpLogEntry { IpAddress = "1.1.1.1", Url = "/a", StatusCode = 500 });
        stats.Add(new HttpLogEntry { IpAddress = "1.1.1.1", Url = "/a", StatusCode = 200 });

        var successful = stats.SuccessfulRequests;

        Assert.Equal(1, successful["1.1.1.1"]);
    }
}
