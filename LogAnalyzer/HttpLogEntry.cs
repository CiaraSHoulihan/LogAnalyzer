namespace LogAnalyzer;

public class HttpLogEntry
{
    public string IpAddress { get; set; } = string.Empty;
    public string? Url { get; set; }
    public int StatusCode { get; set; }
}
