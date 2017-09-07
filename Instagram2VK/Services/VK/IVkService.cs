using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram2VK.ViewModel;

namespace Instagram2VK.Services.VK
{
    interface IVkService
    {
        Task SetWallAsync(string group_id, int timeFrom, int timeTo, IEnumerable<VkItemViewModel> vkItems);
    }
}