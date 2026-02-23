using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer;

public static class ReportPrinter
{
    public static void Print(LogStatistics stats)
    {
        Console.WriteLine($"\nNumber of unique IP addresses: {stats.UniqueIps.Count}");

        Console.WriteLine("\nTop 3 most visited URLs:");
        foreach (var url in stats.UrlCount.OrderByDescending(x => x.Value).Take(3))
        {
            Console.WriteLine($"\t{url.Key} — {url.Value} visits");
        }

        Console.WriteLine("\nTop 3 most active IP addresses (all requests):");
        foreach (var ip in stats.IpCount.OrderByDescending(x => x.Value).Take(3))
        {
            Console.WriteLine($"\t{ip.Key} — {ip.Value} requests");
        }

        Console.WriteLine("\nTop 3 most active IP addresses (successful requests only):");
        foreach (var ip in stats.SuccessfulRequests.OrderByDescending(x => x.Value).Take(3))
        {
            Console.WriteLine($"\t{ip.Key} — {ip.Value} requests");
        }
    }
}
