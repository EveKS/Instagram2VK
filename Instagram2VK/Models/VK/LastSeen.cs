using Newtonsoft.Json;

namespace Instagram2VK.JsonModel.VK
{
    public class LastSeen
    {

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("platform")]
        public int Platform { get; set; }
    }
}
