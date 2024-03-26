using Newtonsoft.Json;
using X.PagedList;
namespace Core.Utilities.Results
{
    public class DataTableNewVersionResult<T>
    {
        [JsonProperty("data")]
        public IPagedList<T> Data { get; set; }
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }
        [JsonProperty("draw")]
        public int Draw { get; set; }
    }
}
