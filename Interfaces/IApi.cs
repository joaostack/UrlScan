using UrlScan.Models;
using System.Threading.Tasks;

namespace UrlScan.Interfaces
{
    public interface IApiRepository
    {
        Task<Root> GetApi(string targetUrl);
    }
}