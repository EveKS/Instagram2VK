﻿using Newtonsoft.Json;

namespace Instagram2VK.Models.Instagram
{
    public class Likes
    {

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
