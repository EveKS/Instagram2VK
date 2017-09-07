using Newtonsoft.Json;

namespace Instagram2VK.JsonModel.VK
{
    public class PostSource
    {
        public string PostSourceId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
