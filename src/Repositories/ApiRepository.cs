using System.Net.Http.Json;
using System.Text.Json;
using UrlScan.Interfaces;
using UrlScan.Models;

namespace UrlScan.Repositories
{
    public class ApiRepository : IApiRepository
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string APIURL = "https://urlscan.io/api/v1/search/?q=domain:";

        public async Task<Root> GetApi(string targetUrl)
        {
            var response = await _client.GetAsync($"{APIURL}{targetUrl}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var root = JsonSerializer.Deserialize<Root>(json);

            return root;
        }
    }
}