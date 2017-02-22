using StructureMap;

namespace ConductOfCode.Core
{
    public class HelloWorldRegistry : Registry
    {
        public HelloWorldRegistry()
        {
            For<IHelloWorld>().Use<HelloWorld>();
            For<IFoo>().Use<Foo>();
            For<IBar>().Use<Bar>();
        }
    }
}