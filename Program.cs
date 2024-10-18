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
            var api = await apiRepository.GetApi("google.com");

            if (api != null)
            {
                foreach (var result in api.results)
                {
                    var resultJson = JsonSerializer.Serialize(result, new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    });

                    rainbow.WriteLineWithMarkup(resultJson);
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
    }
}