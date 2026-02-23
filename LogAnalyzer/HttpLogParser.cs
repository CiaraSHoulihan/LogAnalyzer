using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer;

public static class HttpLogParser
{
    public static HttpLogEntry? Parse(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        string[] parts = line.Split(' ');

        string ip = parts[0];

        int firstQuote = line.IndexOf('"');
        int secondQuote = line.IndexOf('"', firstQuote + 1);

        string? url = null;
        if (firstQuote != -1 && secondQuote != -1)
        {
            string request = line.Substring(firstQuote + 1, secondQuote - firstQuote - 1);
            var reqParts = request.Split(' ');

            if (reqParts.Length >= 2)
            {
                url = reqParts[1];
            }
        }

        int statusCode = -1;
        if (secondQuote != -1)
        {
            string after = line.Substring(secondQuote + 1).Trim();
            var afterParts = after.Split(' ');

            if (afterParts.Length >= 1 && int.TryParse(afterParts[0], out int code))
            {
                statusCode = code;
            }
        }

        return new HttpLogEntry
        {
            IpAddress = ip,
            Url = url,
            StatusCode = statusCode
        };
    }
}
