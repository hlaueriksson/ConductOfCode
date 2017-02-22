using System;
using ConductOfCode.Core;

namespace ConductOfCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IoC.Container.AssertConfigurationIsValid();

            var helloWorld = IoC.Container.GetInstance<IHelloWorld>();

            Console.WriteLine(helloWorld.GetMessage());
        }
    }
}