using Newtonsoft.Json;

namespace Instagram2VK.JsonModel.VK
{
    public class Views
    {
        public string ViewsId { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }
    }
}
