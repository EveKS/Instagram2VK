using Newtonsoft.Json;

namespace Instagram2VK.Models.Instagram
{
    public class Comments
    {

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
