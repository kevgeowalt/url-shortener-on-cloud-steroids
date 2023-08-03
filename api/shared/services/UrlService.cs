namespace shared.services{
    public class UrlService : IUrlService
    {
        public async Task<IServiceResult<string>> RetrieveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IServiceResult<string>> ShortenAsync(string longUrl)
        {
            throw new NotImplementedException();
        }
    }
}