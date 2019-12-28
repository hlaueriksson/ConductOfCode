namespace ConductOfCode
{
    public class HelloWorld
    {
        private readonly IFoo _foo;
        private readonly IBar _bar;

        public HelloWorld(IFoo foo, IBar bar)
        {
            _foo = foo;
            _bar = bar;
        }

        public string GetMessage() => _foo.GetFoo() + _bar.GetBar();
    }

    public interface IFoo
    {
        string GetFoo();
    }

    public interface IBar
    {
        string GetBar();
    }
}