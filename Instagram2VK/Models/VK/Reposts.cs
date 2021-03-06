﻿using Newtonsoft.Json;

namespace Instagram2VK.JsonModel.VK
{
    public class Reposts
    {
        public string RepostsId { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("user_reposted")]
        public int UserReposted { get; set; }
    }
}
