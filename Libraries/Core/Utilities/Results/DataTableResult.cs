using Newtonsoft.Json;
using System.Collections.Generic;
namespace Core.Utilities.Results
{
    public class DataTableResult<T>
    {
        [JsonProperty("aaData")]
        public IEnumerable<T> AaData { get; set; }
        [JsonProperty("sEcho")]
        public int SEcho { get; set; }
        [JsonProperty("iTotalDisplayRecords")]
        public int ITotalDisplayRecords { get; set; }
        [JsonProperty("iTotalRecords")]
        public int ITotalRecords { get; set; }
    }
}
