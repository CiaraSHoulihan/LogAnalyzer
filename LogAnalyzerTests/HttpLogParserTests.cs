
namespace LogAnalyzer.Tests;

public class HttpLogParserTests
{
    [Fact]
    public void Parse_ReturnsNull_ForEmptyLine()
    {
        Assert.Null(HttpLogParser.Parse(""));
    }

    [Fact]
    public void Parse_WhitespaceOnly_ReturnsNull()
    {
        string line = "    ";

        HttpLogEntry? entry = HttpLogParser.Parse(line);

        Assert.Null(entry);
    }

    [Fact]
    public void Parse_ExtractsIpUrlAndStatus()
    {
        string line =
            "72.44.32.11 - - [11/Jul/2018:17:42:07 +0200] \"GET /home HTTP/1.1\" 200 3574";

        HttpLogEntry? entry = HttpLogParser.Parse(line);

        Assert.NotNull(entry);
        Assert.Equal("72.44.32.11", entry.IpAddress);
        Assert.Equal("/home", entry.Url);
        Assert.Equal(200, entry.StatusCode);
    }

    [Fact]
    public void Parse_HandlesMissingQuotes()
    {
        string line =
            "72.44.32.11 - - [11/Jul/2018] GET /home HTTP/1.1 200 3574";

        HttpLogEntry? entry = HttpLogParser.Parse(line)!;

        Assert.NotNull(entry);
        Assert.Equal("72.44.32.11", entry.IpAddress);
        Assert.Null(entry.Url);
        Assert.Equal(-1, entry.StatusCode);
    }
}