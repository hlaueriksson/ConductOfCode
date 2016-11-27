using System;
using System.Diagnostics;

namespace ConductOfCode.Domain
{
    [DebuggerDisplay("{Email}")]
    public class Customer
    {
        public Guid Id { get; }

        public Name Name { get; }

        public Email Email { get; }

        public Customer(Guid id, Name name, Email email)
        {
            if (id == Guid.Empty) throw new Exception("Id is invalid");
            if (name == null) throw new Exception("Name is required");
            if (email == null) throw new Exception("Email is required");

            Id = id;
            Name = name;
            Email = email;
        }
    }

    [DebuggerDisplay("{First,nq} {Last,nq}")]
    public class Name
    {
        public string First { get; }

        public string Last { get; }

        public Name(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first)) throw new Exception("First name is invalid");
            if (string.IsNullOrWhiteSpace(last)) throw new Exception("Last name is invalid");

            First = first;
            Last = last;
        }
    }

    [DebuggerDisplay("{Value}")]
    public class Email : IEquatable<Email>, IEquatable<string>
    {
        public string Value { get; }

        public Email(string value)
        {
            if (!value.Contains("@")) throw new Exception("Email is invalid");

            Value = value;
        }

        #region Conversion

        public static implicit operator string(Email value)
        {
            return value.Value;
        }

        public static implicit operator Email(string value)
        {
            return new Email(value);
        }

        #endregion

        #region Equality

        public override bool Equals(object obj)
        {
            var other = obj as Email;

            return other != null ? Equals(other) : Equals(obj as string);
        }

        public bool Equals(Email other) => other != null && Value == other.Value;

        public bool Equals(string other) => Value == other;

        public static bool operator ==(Email a, Email b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (((object)a == null) || ((object)b == null)) return false;

            return a.Value == b.Value;
        }

        public static bool operator !=(Email a, Email b) => !(a == b);

        #endregion

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}