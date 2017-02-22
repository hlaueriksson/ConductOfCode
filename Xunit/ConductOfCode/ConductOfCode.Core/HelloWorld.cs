namespace ConductOfCode.Core
{
    public interface IHelloWorld
    {
        string GetMessage();
    }

    internal class HelloWorld : IHelloWorld
    {
        private readonly IFoo _foo;
        private readonly IBar _bar;

        public HelloWorld(IFoo foo, IBar bar)
        {
            _foo = foo;
            _bar = bar;
        }

        public string GetMessage()
        {
            return _foo.GetFoo() + _bar.GetBar();
        }
    }

    public interface IFoo
    {
        string GetFoo();
    }

    internal class Foo : IFoo
    {
        public string GetFoo() => "Hello";
    }

    public interface IBar
    {
        string GetBar();
    }

    internal class Bar : IBar
    {
        public string GetBar() => ", World!";
    }
}