using Newtonsoft.Json;
using System.Collections.Generic;

namespace Instagram2VK.Models.Instagram
{
    public class EntryData
    {

        [JsonProperty("ProfilePage")]
        public IList<ProfilePage> ProfilePage { get; set; }
    }
}
