using System;

namespace ConductOfCode.Options
{
    public class TokenOptions
    {
        public string Type { get; set; } = "Bearer";
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(1);

        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SigningKey { get; set; }
    }
}