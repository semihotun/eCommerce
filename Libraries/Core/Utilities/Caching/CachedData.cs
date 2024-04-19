using Newtonsoft.Json;

namespace Core.Utilities.Caching
{
    public class CachedData
    {
        [JsonProperty("DataType")]
        public string DataType { get; set; }
        [JsonProperty("JsonData")]
        public object JsonData { get; set; }
    }
}
