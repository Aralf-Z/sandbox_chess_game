using Newtonsoft.Json;

namespace FastGameDev.Helper
{
    public static class JsonHelper
    {
        public static T DeserializeObject<T>(string file) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(file);
        }
        
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}