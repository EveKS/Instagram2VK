using Newtonsoft.Json;

namespace Instagram2VK.Models.Instagram
{
    public class Follows
    {

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
