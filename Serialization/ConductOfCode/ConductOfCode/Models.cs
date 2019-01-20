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

    // Circular reference

    public class Parent
    {
        public Child Child { get; set; }
    }

    public class Child
    {
        public Parent Parent { get; set; }
    }

    // Polymorphism

    public class Geometry
    {
        public Shape[] Shapes { get; set; }
    }

    public abstract class Shape
    {
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }
    }

    public class Square : Shape
    {
        public int Side { get; set; }
    }
}