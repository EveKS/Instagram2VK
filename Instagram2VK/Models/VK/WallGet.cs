using Newtonsoft.Json;
using System.Collections.Generic;

namespace Instagram2VK.JsonModel.VK
{
    public class WallGet
    {
        public string WallGetId { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        [JsonProperty("profiles")]
        public IList<Profile> Profiles { get; set; }

        [JsonProperty("groups")]
        public IList<GroupInfo> GroupInfos { get; set; }
    }
}
