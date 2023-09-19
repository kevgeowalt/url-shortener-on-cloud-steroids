using Newtonsoft.Json;

namespace shared.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize<T>(this T data)
        {
            if (data is null)
                return string.Empty;

                var str = JsonConvert.SerializeObject(data);
                return str;
        }
    }
}

