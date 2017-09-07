using System.Threading.Tasks;
using Instagram2VK.ViewModel;

namespace Instagram2VK.Services.Instagram
{
    interface IInstagramService
    {
        Task<InstagramLoadViewModel> InstagramLoadAsync(string url);
        Task<InstagramLoadViewModel> InstagramNextAsync(string url, string queryId, string owner, string token);
    }
}