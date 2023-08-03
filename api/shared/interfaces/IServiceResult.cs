namespace shared.services
{
    public interface IServiceResult<T>
    {
        T Data { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }
}