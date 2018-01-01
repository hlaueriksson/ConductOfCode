using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConductOfCode.Xml
{
    public static class Extensions
    {
        public static string ToXml<T>(this T value, bool indent = true)
        {
            var serializer = new XmlSerializer(typeof(T));
            var writer = new StringWriter();
            serializer.Serialize(XmlWriter.Create(writer, new XmlWriterSettings { Indent = indent }), value);
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