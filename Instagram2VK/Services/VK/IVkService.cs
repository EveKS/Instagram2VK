using Instagram2VK.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram2VK.Services.VK
{
    interface IVkService
    {
        event EventHandler AppendProgressMaxValue;
        event EventHandler AppendProgressMessage;
        event EventHandler AppendProgressValue;

        Task SetWallAsync(string group_id, string access_token, int timeFrom, int timeTo, IEnumerable<VkItemViewModel> vkItems);
    }
}