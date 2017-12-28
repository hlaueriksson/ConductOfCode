using System;
using System.Collections.Generic;

namespace ConductOfCode
{
    public class Subject
    {
        public bool Bool { get; set; }
        public double Double { get; set; }
        public int Int { get; set; }
        public string String { get; set; }
        public bool? Nullable { get; set; }

        public DateTime DateTime { get; set; }
        public Enum Enum { get; set; }
        public Guid Guid { get; set; }

        public List<Foo> List { get; set; }
    }

    public enum Enum
    {
        Fizz,
        Buzz
    }

    public class Foo
    {
        public long Id { get; set; }
        public Bar Bar { get; set; }
    }

    public class Bar
    {
        public long Id { get; set; }
    }

    public class Problem
    {
        public Dictionary<string, Bar> Dictionary { get; set; }
        public Tuple<Foo, Bar> Tuple { get; set; }
        public Uri Uri { get; set; }
    }

    // circular references

    public class A
    {
        public int Id { get; set; }

        public B B { get; set; }
    }

    public class B
    {
        public string Ref { get; set; }

        public A A { get; set; }
    }

    // polymorphism

    public class C
    {
        public D D { get; set; }
    }

    public abstract class D
    {
    }

    public class D1 : D
    {
        public int Id { get; set; }
    }

    public class D2 : D
    {
        public string Ref { get; set; }
    }
}