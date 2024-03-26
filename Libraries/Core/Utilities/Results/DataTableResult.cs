using Newtonsoft.Json;
using X.PagedList;
namespace Core.Utilities.Results
{
    public class DataTableResult<T>
    {
        [JsonProperty("aaData")]
        public IPagedList<T> AaData { get; set; }
        [JsonProperty("sEcho")]
        public int SEcho { get; set; }
        [JsonProperty("iTotalDisplayRecords")]
        public int ITotalDisplayRecords { get; set; }
        [JsonProperty("iTotalRecords")]
        public int ITotalRecords { get; set; }
    }
}
