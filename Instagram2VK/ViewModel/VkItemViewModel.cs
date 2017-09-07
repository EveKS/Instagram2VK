using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram2VK.ViewModel
{
    public class VkItemViewModel
    {
        public int? Likes { get; set; }
        public int? Views { get; set; }
        public int? Reposts { get; set; }
        public int? Coments { get; set; }

        public string GroupId { get; set; }
        public string ItemId { get; set; }
        public string Statuse { get; set; }
        public IEnumerable<string> Gif { get; set; }
        public IEnumerable<string> DocExt { get; set; }

        public string Tags { get; set; }

        public long PublishDate { get; set; }
        public long? Date { get; set; }
        public string Text { get; set; }
        public IEnumerable<String> Photo { get; set; }
    }
}
