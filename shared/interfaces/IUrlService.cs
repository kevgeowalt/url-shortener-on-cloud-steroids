namespace shared.services{
    public interface IUrlService{
        Task<IServiceResult<string>> ShortenAsync(string longUrl);
        Task<IServiceResult<string>> RetrieveAsync(string id);
        Task<IServiceResult<string>> VerifyApiWorking();
    }
}