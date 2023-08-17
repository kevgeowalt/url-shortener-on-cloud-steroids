
using System.Text;
using Azure.Data.Tables;
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
        private readonly string _tableName = string.Empty;
        public UrlService(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = string.IsNullOrWhiteSpace(tableName) ? "" : tableName;
        }
        public async Task<IServiceResult<string>> RetrieveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IServiceResult<string>> ShortenAsync(string longUrl)
        {
            IServiceResult<string> result = new CreateResult<string>() { Data = string.Empty, Success = false, Message = string.Empty };
            try
            {
                string randomCode = GenerateRandomStr();

                var client = await GetTableClientAsync();
                var entity = new TableEntity(randomCode, longUrl
                            .Replace("/","{forward}")
                            .Replace("\\","backward")
                            .Replace("#","numbersgn")
                            .Replace("?","questionmrk"));

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
            TableClient tableClient = new TableClient(_connectionString, _tableName);
            return tableClient;
        }

        public async Task<bool> AddAsync(TableClient client, TableEntity entity)
        {
            var result = client.AddEntity(entity);
            return result.Status.ToString().StartsWith("20") ? true : false;
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
    }
}