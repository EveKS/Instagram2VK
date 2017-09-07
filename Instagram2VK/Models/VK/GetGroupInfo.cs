using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram2VK.JsonModel.VK
{
    public class GetGroupInfo
    {
        [JsonProperty("response")]
        public IList<GroupInfo> GroupsInfo { get; set; }
    }
}
