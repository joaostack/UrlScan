using System.Text.Json;
using UrlScan.Repositories;

namespace UrlScan
{
    public class Program
    {
        static async Task Main()
        {
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

                    Console.WriteLine(resultJson);
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
    }
}