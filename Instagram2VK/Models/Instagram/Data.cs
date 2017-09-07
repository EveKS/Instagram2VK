using Newtonsoft.Json;

namespace Instagram2VK.Models.Instagram
{
    public class Data
    {

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
