using Newtonsoft.Json;

namespace Instagram2VK.Models.Instagram
{
    public class Config
    {

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }

        [JsonProperty("viewer")]
        public object Viewer { get; set; }
    }
}
