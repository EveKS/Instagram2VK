using Newtonsoft.Json;

namespace Instagram2VK.Models.Instagram
{
    public class FollowedBy
    {

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
