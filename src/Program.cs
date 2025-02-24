using System.Text.Json;
using Lolcat;
using UrlScan.Repositories;

namespace UrlScan
{
    public class Program
    {
        static readonly RainbowStyle style = new RainbowStyle();
        static readonly Rainbow rainbow = new Rainbow(style);

        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                rainbow.WriteLineWithMarkup("USE: ./urlscan domain.com");
                return;
            }

            ApiRepository apiRepository = new ApiRepository();
            var api = await apiRepository.GetApi(args[0]);

            if (api != null)
            {
                foreach (var result in api.results)
                {
                    var resultJson = JsonSerializer.Serialize(result, new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    });

                    rainbow.WriteLineWithMarkup($"URL: {result.page.url}");
                    rainbow.WriteLineWithMarkup($"IP: {result.page.ip}");
                    rainbow.WriteLineWithMarkup($"ASN: {result.page.asn}");
                    rainbow.WriteLineWithMarkup($"ASN Name: {result.page.asnname}");
                    rainbow.WriteLineWithMarkup($"Status: {result.page.status}");
                    rainbow.WriteLineWithMarkup($"Title: {result.page.title}");
                    rainbow.WriteLineWithMarkup($"Country: {result.page.country}");
                    rainbow.WriteLineWithMarkup($"Server: {result.page.server ?? "Not Found"}");
                    rainbow.WriteLineWithMarkup($"Screenshot: {result.screenshot}");
                    rainbow.WriteLineWithMarkup($"Requests: {result.stats.requests}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
    }
}
