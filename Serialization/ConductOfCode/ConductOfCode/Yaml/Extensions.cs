using YamlDotNet.Serialization;

namespace ConductOfCode.Yaml
{
    public static class Extensions
    {
        public static string ToYaml<T>(this T value)
        {
            var serializer = new SerializerBuilder().Build();
            return serializer.Serialize(value);
        }

        public static T FromYaml<T>(this string value)
        {
            var deserializer = new DeserializerBuilder().Build();
            return deserializer.Deserialize<T>(value);
        }
    }
}