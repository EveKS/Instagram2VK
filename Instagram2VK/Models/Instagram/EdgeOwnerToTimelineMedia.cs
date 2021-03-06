﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Instagram2VK.Models.Instagram
{
    public class EdgeOwnerToTimelineMedia
    {

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("edges")]
        public IList<Edge> Edges { get; set; }
    }
}
