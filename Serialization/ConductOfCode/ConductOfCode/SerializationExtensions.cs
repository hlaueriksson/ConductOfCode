namespace ConductOfCode
{
    public static class SerializationExtensions
    {
        // XML

        public static string ToXml<T>(this T value)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var writer = new System.IO.StringWriter();
            serializer.Serialize(writer, value);
            return writer.ToString();
        }

        public static T FromXml<T>(this string value)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var reader = new System.IO.StringReader(value);
            return (T)serializer.Deserialize(reader);
        }

        // JSON

        public static string ToJson<T>(this T value, Newtonsoft.Json.Formatting formatting = Newtonsoft.Json.Formatting.Indented)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value, formatting);
        }

        public static T FromJson<T>(this string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }

        // YAML

        public static string ToYaml<T>(this T value)
        {
            var serializer = new YamlDotNet.Serialization.SerializerBuilder().Build();
            return serializer.Serialize(value);
        }

        public static T FromYaml<T>(this string value)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder().Build();
            return deserializer.Deserialize<T>(value);
        }

        // TOML

        public static string ToToml<T>(this T value)
        {
            return Nett.Toml.WriteString(value);
        }

        public static T FromToml<T>(this string value)
        {
            return Nett.Toml.ReadString<T>(value);
        }
    }
}