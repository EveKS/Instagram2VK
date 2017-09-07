using Newtonsoft.Json;

namespace Instagram2VK.Models.Instagram
{
    public class Edge
    {

        [JsonProperty("node")]
        public Node Node { get; set; }
    }
}
