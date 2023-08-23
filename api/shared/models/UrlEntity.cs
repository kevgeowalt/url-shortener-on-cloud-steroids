using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json;

namespace shared.Entities
{
    public class UrlEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = string.Empty;
        public string RowKey { get; set; } = string.Empty;
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        [JsonProperty(PropertyName = "longUrl")]
        public string LongUrl { get; set; } = string.Empty;
    }
}