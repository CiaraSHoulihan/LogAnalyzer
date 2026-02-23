using LogAnalyzer.Interfaces;
using LogAnalyzer.Models;
using LogAnalyzer.Services;

namespace LogAnalyzer.Tests;

public class HttpLogParserTests
{
    private readonly IHttpLogParser _parser;

    public HttpLogParserTests() 
    { 
        _parser = new HttpLogParser(); 
    }

    [Fact]
    public void Parse_ReturnsNull_ForEmptyLine()
    {
        Assert.Null(_parser.Parse(""));
    }

    [Fact]
    public void Parse_WhitespaceOnly_ReturnsNull()
    {
        string line = "    ";

        HttpLogEntry? entry = _parser.Parse(line);

        Assert.Null(entry);
    }

    [Fact]
    public void Parse_ExtractsIpUrlAndStatus()
    {
        string line =
            "72.44.32.11 - - [11/Jul/2018:17:42:07 +0200] \"GET /home HTTP/1.1\" 200 3574";

        HttpLogEntry? entry = _parser.Parse(line);

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

        HttpLogEntry? entry = _parser.Parse(line)!;

        Assert.NotNull(entry);
        Assert.Equal("72.44.32.11", entry.IpAddress);
        Assert.Null(entry.Url);
        Assert.Equal(-1, entry.StatusCode);
    }
}