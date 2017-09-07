using Newtonsoft.Json;
using System.Collections.Generic;

namespace Instagram2VK.Models.Instagram
{
    public class EdgeMediaToCaption
    {

        [JsonProperty("edges")]
        public IList<Edge> Edges { get; set; }
    }
}
