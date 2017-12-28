using System.IO;
using System.Xml.Serialization;

namespace ConductOfCode.Xml
{
    public static class Extensions
    {
        public static string ToXml<T>(this T value)
        {
            var serializer = new XmlSerializer(typeof(T));
            var writer = new StringWriter();
            serializer.Serialize(writer, value);
            return writer.ToString();
        }

        public static T FromXml<T>(this string value)
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = new StringReader(value);
            return (T)serializer.Deserialize(reader);
        }
    }
}