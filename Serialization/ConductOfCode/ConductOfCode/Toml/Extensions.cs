namespace ConductOfCode.Toml
{
    public static class Extensions
    {
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