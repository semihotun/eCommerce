using Newtonsoft.Json;
using System.Collections.Generic;
namespace Core.Utilities.Results
{
    public class DataTableNewVersionResult<T>
    {
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }
        [JsonProperty("draw")]
        public int Draw { get; set; }
    }
}
