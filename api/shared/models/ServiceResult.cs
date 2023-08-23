using shared.services;

namespace shared.Models{
    public class CreateResult<T> : IServiceResult<T>
    {
        public CreateResult()
        {
            
        }
        public CreateResult(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message {get;set;} = string.Empty;
    }

    public class GetResult<T> : IServiceResult<T>
    {
        public GetResult()
        {
            
        }
        public GetResult(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message {get;set;} = string.Empty;
    }
}