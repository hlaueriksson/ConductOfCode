using Newtonsoft.Json;

namespace ConductOfCode.Json
{
    public static class Extensions
    {
        public static string ToJson<T>(this T value, Formatting formatting = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(value, formatting);
        }

        public static T FromJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}