using System;

namespace ConductOfCode.Data
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public NameDto Name { get; set; }

        public EmailDto Email { get; set; }
    }

    public class NameDto
    {
        public string First { get; set; }

        public string Last { get; set; }
    }

    public class EmailDto
    {
        public string Value { get; set; }
    }
}
