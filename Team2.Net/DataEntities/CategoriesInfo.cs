using System.Collections.Generic;
using Newtonsoft.Json;

namespace Team2.Net.DataEntities
{
    public class CategoriesInfo
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }
}
