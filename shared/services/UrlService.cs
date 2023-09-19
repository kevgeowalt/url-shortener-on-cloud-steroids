
using System.Text;
using Azure.Data.Tables;
using Azure.Identity;
using shared.Entities;
using shared.Models;

namespace shared.services
{
    public class UrlService : IUrlService
    {
        /*
        dotnet add package Microsoft.Azure.Cosmos.Table
        dotnet add package Azure.Data.tables
        */
        private readonly string _connectionString = string.Empty;
        private readonly string _tableUri;
        private readonly string _tableName = string.Empty;
        public UrlService(string tableUri, string tableName)
        {
            _tableUri = tableUri;
            _tableName = string.IsNullOrWhiteSpace(tableName) ? "" : tableName;
        }
        public async Task<IServiceResult<string>> RetrieveAsync(string id)
        {
            IServiceResult<string> result = new CreateResult<string>() { Data = string.Empty, Success = false, Message = string.Empty };
            try
            {
                var client = await GetTableClientAsync();
                var getResult = await GetAsync(client, id);

                result.Data = getResult;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<IServiceResult<string>> ShortenAsync(string longUrl)
        {
            IServiceResult<string> result = new CreateResult<string>() { Data = string.Empty, Success = false, Message = string.Empty };
            try
            {
                string randomCode = GenerateRandomStr();

                var client = await GetTableClientAsync();

                longUrl = longUrl.Replace("/", "{forward}")
                            .Replace("\\", "backward")
                            .Replace("#", "numbersgn")
                            .Replace("?", "questionmrk");

                var entity = new TableEntity("GENERAL", randomCode){
                    {"LongUrl", longUrl },
                };

                var newResult = await AddAsync(client, entity);

                if (newResult)
                {
                    result.Message = randomCode;
                    result.Success = true;
                    result.Message = "Successfully stored record";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<TableClient> GetTableClientAsync()
        {
            var tableClient = new TableClient(new Uri(_tableUri),_tableName,new DefaultAzureCredential());
            return tableClient;
        }

        public async Task<bool> AddAsync(TableClient client, TableEntity entity)
        {
            var result = await client.AddEntityAsync(entity);
            return result.Status.ToString().StartsWith("20") ? true : false;
        }

        public async Task<string> GetAsync(TableClient client, string code)
        {
            Azure.Response<UrlEntity> result = await client.GetEntityAsync<UrlEntity>("GENERAL", code);

            if (string.IsNullOrWhiteSpace(result.Value.RowKey))
                return string.Empty;

            return result.Value.LongUrl.Replace("{forward}","/").Replace("backward","\\").Replace("numbersgn","?").Replace("questionmrk","?");
        }

        public string GenerateRandomStr()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 5;
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }

            return sb.ToString();
        }

        public async Task<IServiceResult<string>> VerifyApiWorking()
        {
            return new CreateResult<string>(){ Data = "Api is reading from shared", Success = true, Message = string.Empty };
        }
    }
}