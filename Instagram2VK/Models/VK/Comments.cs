﻿using Newtonsoft.Json;

namespace Instagram2VK.JsonModel.VK
{
    public class Comments
    {
        public string CommentsId { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("can_post")]
        public int CanPost { get; set; }
    }
}
