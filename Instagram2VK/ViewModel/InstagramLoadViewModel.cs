using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram2VK.ViewModel
{
    class InstagramLoadViewModel
    {
        public string Token { get; set; }
        public string Owner { get; set; }
        public string Error { get; set; }

        public IEnumerable<VkItemViewModel> VkItemViewModels { get; set; }
    }
}
