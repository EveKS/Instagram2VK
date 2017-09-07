using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Instagram2VK.Services.Html
{
    interface IHtmlService
    {
        Task<string> GetAsync(string url, HttpCompletionOption httpCompletionOption = default(HttpCompletionOption));
        Task<Stream> GetStreamAsync(string url, HttpCompletionOption httpCompletionOption = default(HttpCompletionOption));
        Task<string> PostAsync(string url, FormUrlEncodedContent formContent);
        Task<string> PostStreamAsync(string url, MultipartFormDataContent formContent);
    }
}