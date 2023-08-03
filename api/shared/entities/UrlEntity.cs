using Microsoft.Azure.Cosmos.Table;

namespace shared.Entities{
    public class UrlEntity: TableEntity{
        public UrlEntity()
        {
            
        }

        public UrlEntity(string longUrl, string code)
        {
            PartitionKey = code; // throughput key
            RowKey = longUrl; //primary key in partitiion
        }

        public string LongUrl { get; set; }
        public string Code { get; set; }
    }
}